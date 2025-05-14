using HomeRentTracker.Models;
using HomeRentTracker.Models.LoginEntity;
using HomeRentTracker.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlatRentTracker.Controllers
{
    public class LoginModelController : Controller
    {
         private readonly IUserRepository _userRepository;
        public LoginModelController( IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_LoginModal", model); // return modal with validation

           UserRegistration registration = await _userRepository.UserLogin(model.userID, model.userPassword);

            if (registration.IsSuccess)
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
