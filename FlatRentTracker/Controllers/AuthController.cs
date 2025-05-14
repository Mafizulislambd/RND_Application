using FlatRentTracker.Models;
using FlatRentTracker.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlatRentTracker.Controllers
{
    // Controllers/AuthController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IUserRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        // Controllers/AuthController.cs
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var result = await _repo.CheckLoginAsync(request);
            if (!result.IsSuccess)
                return Unauthorized(new { result.ErrorMessage });

            var token = JwtHelper.GenerateToken(_config, result);
            return Ok(new { token, user = result });
        }
        //[Authorize]
        //public IActionResult Dashboard() => View();
        //[Authorize]
        //public IActionResult Dashboard() => View();

    }

}
