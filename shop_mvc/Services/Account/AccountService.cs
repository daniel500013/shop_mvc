using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace shop_mvc.Services.Account
{
    public class AccountService
    {
        private UserModel collection;

        public AccountService(UserModel collection)
        {
            this.collection = collection;
        }

        public async Task<bool> Login(IPasswordHasher<UserModel> passwordHasher, HttpContext httpContext)
        {
            using (var context = new ShopDbContext())
            {
                var user = await context.User.SingleOrDefaultAsync(x => x.Email == collection.Email);

                if (user != null)
                {
                    var checkPassword = passwordHasher.VerifyHashedPassword(collection, user.HashPassword, collection.Password);

                    if (checkPassword == PasswordVerificationResult.Success)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, (context.User.ToList().Count+1).ToString()),
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

                        await httpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        public async Task<bool> Register(HttpContext httpContext, IPasswordHasher<UserModel> passwordHasher, ModelStateDictionary ModelState)
        {
            using (var context = new ShopDbContext())
            {
                var CheckEmailDuplicate = await context.User.FirstOrDefaultAsync(x => x.Email == collection.Email);

                if (CheckEmailDuplicate != null)
                {
                    ModelState.AddModelError("InvalidRegister", "Podany email został już wykorzystany");
                    return false;
                }

                var passwordHash = passwordHasher.HashPassword(collection, collection.Password);

                collection.HashPassword = passwordHash;

                await context.AddAsync(collection);
                await context.SaveChangesAsync();

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, (context.User.ToList().Count+1).ToString()),
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

                await httpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return true;
            }
        }
    }
}
