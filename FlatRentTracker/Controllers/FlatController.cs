using FlatRentTracker.Models;
using FlatRentTracker.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlatRentTracker.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        public async Task<IActionResult> Index()
        {
            var flats = await _flatService.GetAllFlatsAsync();
            return View(flats);
        }

        public async Task<IActionResult> Details(int id)
        {
            var flat = await _flatService.GetFlatByIdAsync(id);
            if (flat == null) return NotFound();
            return View(flat);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Flat flat)
        {
            if (ModelState.IsValid)
            {
                await _flatService.InsertFlatAsync(flat);
                return RedirectToAction(nameof(Index));
            }
            return View(flat);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var flat = await _flatService.GetFlatByIdAsync(id);
            if (flat == null) return NotFound();
            return View(flat);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Flat flat)
        {
            if (ModelState.IsValid)
            {
                await _flatService.UpdateFlatAsync(flat);
                return RedirectToAction(nameof(Index));
            }
            return View(flat);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var flat = await _flatService.GetFlatByIdAsync(id);
            if (flat == null) return NotFound();
            return View(flat);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _flatService.DeleteFlatAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
