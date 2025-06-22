using HomeRentTracker.Models.RenterEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HomeRentTracker.Controllers
{

    public class RenterController : Controller
    {
        private readonly IRenterService _service;

        public RenterController(IRenterService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var renters = await _service.GetAllAsync();
            return View(renters);
        }


        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(RenterInfo renter)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(renter);
                return RedirectToAction(nameof(Index));
            }
            return View(renter);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var renter = await _service.GetByIdAsync(id);
            if (renter == null) return NotFound();
            return View(renter);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RenterInfo renter)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(renter);
                return RedirectToAction(nameof(Index));
            }
            return View(renter);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var renter = await _service.GetByIdAsync(id);
            if (renter == null) return NotFound();
            return View(renter);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int id)
        {
            var renter = await _service.GetByIdAsync(id);
            if (renter == null) return NotFound();
            return View(renter);
        }
    }

}
