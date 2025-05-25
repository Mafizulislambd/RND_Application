using HomeRentTracker.Models;
using HomeRentTracker.Models.LoginEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace FlatRentTracker.Controllers
{
    public class LoginModelController : Controller
    {
         private readonly IUserServices _userRepository;
        public LoginModelController(IUserServices userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView("_LoginModal", model); // return modal with validation

           // UserRegistration registration = await _userRepository.RegisterUser(model.userID, model.userPassword);

            //if (registration.IsSuccess)
            //    return Json(new { success = true });

            //ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return PartialView("_LoginModal", model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return PartialView("_LoginModal", new LoginViewModel());
        }
    }
}
