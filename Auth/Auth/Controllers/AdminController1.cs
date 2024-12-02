using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Controllers
{
    public class AdminController1 : Controller
    {
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() => View();

        public async Task<IActionResult> Login(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, IsPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Admin");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await -sighInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult AccesDenied => View();
    }
}
