using HomeRentTracker.Models;
using HomeRentTracker.Models.LoginEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeRentTracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserServices _userService;
        private readonly UserManager<UserInfo> _userManager;
        private readonly SignInManager<UserInfo> _signInManager;
        public AccountController(IUserServices userServices, UserManager<UserInfo> userManager, SignInManager<UserInfo> signInManager)
        {
            _userService = userServices;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserInfo user = await _userManager.FindByNameAsync(model.userName);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.userPassword))
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    HttpContext.Session.SetString("Username", user.UserName);
                    HttpContext.Session.SetString("FullName", user.FullName);
                    return Ok(new { message = "Success" });
                }

                return BadRequest("Invalid credentials");

                //var user = _userService.ValidateUser(model.Username, model.Password);
                //if (user != null)
                //{
                //    HttpContext.Session.SetString("Username", user.UserName);
                //    HttpContext.Session.SetString("FullName", user.FullName);

                //    CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddMinutes(30) };
                //    Response.Cookies.Append("UserId", user.UserName.ToString(), options);

                //    return RedirectToAction("Index", "Home");
                //}

                //ModelState.AddModelError("", "Invalid credentials");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(UserInfo model)
        {
            if (ModelState.IsValid)
            {
                //int result = _userService.RegisterUser(model.UserName, model.UserFistName, model.UserMiddleName, model.UserLastName, model.FullName, model.UserEmail, model.UserPhone, model.UserPassword);
                int result=_userManager.CreateAsync(new UserInfo
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserName,
                    UserFirstName = model.UserFirstName,
                    UserMiddleName = model.UserMiddleName,
                    UserLastName = model.UserLastName,
                    FullName = model.FullName,
                    UserPassword = model.UserPassword,
                    UserEmail = model.UserEmail,
                    UserPhone = model.UserPhone,
                    PasswordHash = model.UserPassword,
                    Email = model.UserEmail,
                    PhoneNumber = model.UserPhone,

                }, model.UserPassword).Result.Succeeded ? 1 : -1;
                if (result == -1)
                {
                    ModelState.AddModelError("", "Username already exists.");
                    return View(model);
                }

                TempData["Success"] = "Registration successful! Please login.";
                return RedirectToAction("Login");
            }

            return View(model);
        }     
      
        [HttpPost]
        public async Task<IActionResult> LoginNew(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                //return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid credentials";
            return View();

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            Response.Cookies.Delete("UserId");
            //   return        NoContent();
            return Ok();

        }
       

    }
}
