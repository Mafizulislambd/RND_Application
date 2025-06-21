using HomeRentTracker.Models.FlatEntity;
using HomeRentTracker.Models.Owner;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace HomeRentTracker.Controllers
{
    public class FlatController : Controller
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService flatService)
        {
            _flatService = flatService;
        }

        public async Task<IActionResult> FlatList()
        {
           IEnumerable<Flat> flatList = await _flatService.GetAllFlatsAsync();
            return View( flatList) ;
        }
        public  IActionResult FlatAll() { 
            return View("FlatAll");
        }   
        public  IActionResult Index() { 
            return View("FlatAll");
        }
        public async Task<IActionResult> Details(int id)
        {
            var flat = await _flatService.GetFlatByIdAsync(id);
            if (flat == null) return NotFound();
            return View(flat);
        }

        public async Task< IActionResult> Create() // This method is for rendering the Create view.
        {
            var owners = _flatService.GetOwnerList().Result; // Ensure the task is awaited or resolved
            var viewModel = new FlatViewModel
            {
                OwnerList = owners.Select(o => new SelectListItem
                {
                    Value = o.OwnerName.ToString(),
                    Text = o.OwnerName
                }).ToList(),
               

            };
            

            return View(viewModel); // Pass the viewModel to the view
        }

        [HttpPost]
        public async Task<IActionResult> Create(Flat flat)
        {
            if (ModelState.IsValid)
            {
                await _flatService.InsertFlatAsync(flat);
                return RedirectToAction(nameof(FlatList));
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
                return RedirectToAction(nameof(FlatList));
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
            return RedirectToAction(nameof(FlatList));
        }
    }
}
