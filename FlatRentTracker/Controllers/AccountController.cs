using FlatRentTracker.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FlatRentTracker.Controllers
{
    public class AccountController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IConfiguration _config;

        //public AccountController(IHttpClientFactory httpClientFactory, IConfiguration config)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _config = config;
        //}

        //[HttpGet]
        //public IActionResult Login() => View();

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var client = _httpClientFactory.CreateClient();
        //    var apiUrl = _config["JwtLoginApiUrl"]; // e.g., "https://localhost:5001/api/auth/login"

        //    var response = await client.PostAsJsonAsync(apiUrl, model);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadFromJsonAsync<JwtLoginResponse>();
        //        HttpContext.Session.SetString("JWToken", json!.Token);
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid credentials.");
        //    return View(model);
        //}

        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login");
        //}
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public AccountController(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    var client = _httpClientFactory.CreateClient();
        //    var apiUrl = _config["JwtLoginApiUrl"]; // e.g., "https://localhost:5001/api/auth/login"

        //    var response = await client.PostAsJsonAsync(apiUrl, model);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json = await response.Content.ReadFromJsonAsync<JwtLoginResponse>();
        //        HttpContext.Session.SetString("JWToken", json!.Token);
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ModelState.AddModelError(string.Empty, "Invalid credentials.");
        //    return View(model);
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(_config["JwtLoginApiUrl"], model);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "Invalid credentials.");
                return View(model);
            }

            var result = await response.Content.ReadFromJsonAsync<JwtLoginResponse>();
            var token = result!.Token;

            var handler = new JwtSecurityTokenHandler();
            var jwt = handler.ReadJwtToken(token);

            var identity = new ClaimsIdentity(jwt.Claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = jwt.ValidTo
            });

            // Optionally store token in cookie for API calls
            Response.Cookies.Append("access_token", token, new CookieOptions
            {
                HttpOnly = true,
                Expires = jwt.ValidTo
            });

            return RedirectToAction("Index", "Home");
        }


        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Clear();
        //    return RedirectToAction("Login");
        //}
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            Response.Cookies.Delete("access_token");
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult AccessDenied() => View();
    }

}
