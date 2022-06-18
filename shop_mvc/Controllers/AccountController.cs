using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace shop_mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly ShopDbContext context;
        private IPasswordHasher<UserModel> passwordHasher;

        public AccountController(ShopDbContext _context, IPasswordHasher<UserModel> _passwordHasher)
        {
            context = _context;
            passwordHasher = _passwordHasher;
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
            var user = await context.User.SingleOrDefaultAsync(x => x.Email == collection.Email);
        
            if (user != null)
            {
                var checkPassword = passwordHasher.VerifyHashedPassword(collection, user.HashPassword, collection.Password);

                if (checkPassword == PasswordVerificationResult.Success)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                        IsPersistent = false,
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return LocalRedirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("InvalidLogin", "Podane hasło jest nieprawidłowe");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("InvalidLogin", "Nie istnieje użytkownik o takim emailu");
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
                var CheckEmailDuplicate = await context.User.FirstOrDefaultAsync(x => x.Email == collection.Email);

                if (CheckEmailDuplicate != null)
                {
                    ModelState.AddModelError("InvalidRegister", "Podany email został już wykorzystany");
                    return View();
                }

                var passwordHash = passwordHasher.HashPassword(collection, collection.Password);

                collection.HashPassword = passwordHash;

                await context.AddAsync(collection);
                await context.SaveChangesAsync();

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, collection.Email),
                        new Claim(ClaimTypes.Role, collection.Role),
                    };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1),
                    IsPersistent = false,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return LocalRedirect("/Home/Index");
            }
            else
            {
                ModelState.AddModelError("InvalidRegister", "Podane dane są niepoprawne sprawdź je przed rejestracją");
                return View();
            }
        }
    }
}
