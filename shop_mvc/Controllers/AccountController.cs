using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop_mvc.Services.Account;

namespace shop_mvc.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService accountService;
        private IPasswordHasher<UserModel> passwordHasher;

        public AccountController(IPasswordHasher<UserModel> _passwordHasher, IAccountService accountService)
        {
            passwordHasher = _passwordHasher;
            this.accountService = accountService;
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        // GET: Logout
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return LocalRedirect("/Home/Index");
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserModel collection)
        {
            var loginService = await accountService.Login(collection, passwordHasher, HttpContext);

            if (loginService)
            {
                return LocalRedirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError("InvalidLogin", "Podane dane są nieprawidłowe");
                return View();
            }
        }

        // POST: AccountController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserModel collection)
        {
            ModelState.ClearValidationState(nameof(collection));
            if (!TryValidateModel(collection, nameof(collection)))
            {
                var registerService = await accountService.Register(collection, HttpContext, passwordHasher, ModelState);

                if (registerService)
                {
                    return LocalRedirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("InvalidRegister", "Podany email już istnieje!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("InvalidRegister", "Podane dane są nieprawidłowe!");
                return View();
            }
        }
    }
}
