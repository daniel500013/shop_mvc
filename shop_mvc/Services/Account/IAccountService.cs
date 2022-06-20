using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace shop_mvc.Services.Account
{
    public interface IAccountService
    {
        Task<bool> Login(UserModel collection, IPasswordHasher<UserModel> passwordHasher, HttpContext httpContext);
        Task<bool> Register(UserModel collection, HttpContext httpContext, IPasswordHasher<UserModel> passwordHasher, ModelStateDictionary ModelState);
    }
}
