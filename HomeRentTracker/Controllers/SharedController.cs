using Microsoft.AspNetCore.Mvc;

namespace HomeRentTracker.Controllers
{
    public class SharedController : Controller
    {
        public IActionResult ReloadHeader()
        {
            return PartialView("_HeaderPartial");
        }
    }
}
