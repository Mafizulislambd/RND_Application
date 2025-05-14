using FlatRentTracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlatRentTracker.Controllers
{
    public class LoginModelController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginModelController(SignInManager<IdentityUser> signInManager)
        {
              _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_LoginModal", model); // return modal with validation

            var result = await _signInManager.PasswordSignInAsync(model.userID, model.userPassword, model.RememberMe, false);

            if (result.Succeeded)
                return Json(new { success = true });

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return PartialView("_LoginModal", model);
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return PartialView("_LoginModal", new LoginModel());
        //}
    }
}
