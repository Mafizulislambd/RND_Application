using AppDataIntigrity.Models;
using AppDataIntigrity.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using AppDataIntigrity.Data;
using Microsoft.AspNetCore.Identity;

namespace AppDataIntigrity.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly SignInManager<IdentityUser> _signInManager; // Add this field

        public AccountController(ApplicationDbContext context, IAccountService accountService, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _accountService = accountService;
            _signInManager = signInManager; // Initialize the field
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }

}
