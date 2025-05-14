using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FlatRentTracker.Controllers
{
    public class SecureDataController : Controller
    {
        //private readonly IHttpClientFactory _httpClientFactory;

        //public SecureDataController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;
        //}

        //public async Task<IActionResult> Index()
        //{
        //    var token = HttpContext.Session.GetString("JWToken");
        //    if (string.IsNullOrEmpty(token))
        //        return RedirectToAction("Login", "Account");

        //    var client = _httpClientFactory.CreateClient();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        //    var response = await client.GetAsync("https://localhost:5001/api/secure-data");
        //    var data = await response.Content.ReadAsStringAsync();

        //    ViewBag.Data = data;
        //    return View();
        //}
        private readonly IHttpClientFactory _httpClientFactory;

        public SecureDataController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            if (string.IsNullOrEmpty(token))
                return RedirectToAction("Login", "Account");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("https://localhost:5001/api/secure-data");
            var data = await response.Content.ReadAsStringAsync();

            ViewBag.Data = data;
            return View();
        }
        [Authorize]
        [HttpGet("secure-data")]
        public IActionResult GetSecureData() => Ok("Only authenticated users see this.");
    }
}


