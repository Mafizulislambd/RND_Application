using HomeRentTracker.Models.OwnerEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeRentTracker.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _repository;

        public OwnerController(IOwnerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(string searchText, int page = 1)
        {
            var filter = new OwnerFilterViewModel
            {
                SearchText = searchText,
                PageNumber = page,
                PageSize = 10
            };

            await _repository.GetAllOwnersAsync(filter);
            return View(filter);
        }

        public async Task<IActionResult> Details(int id)
        {
            var owner = await _repository.GetOwnerByIdAsync(id);
            if (owner == null) return NotFound();
            return View(owner);
        }

        // The error CS0111 occurs because there are two methods named 'Create' in the OwnerController class with the same parameter types.
        // To fix this, we need to rename one of the methods or differentiate their parameter types.
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            OwnerInfo own = new OwnerInfo();

            if (id > 0)
            {
                own = await _repository.GetOwnerByIdAsync(id);

            }           
           own.OwnerInfoList = _repository.GetOwnerListAll().Result; // Ensure the task is awaited or resolved
            
            return View(own); // Pass the viewModel to the view
        }

        [HttpPost]
        public async Task<IActionResult> Create(OwnerInfo owner) // This method is for handling form submission.
        {
            OwnerInfo obj = new OwnerInfo();
            if (!ModelState.IsValid)
                return View(owner);

            //owner.CreatedDate = DateTime.Now;
            //owner.UpdatedDate = DateTime.Now;
            bool success;
            if (owner.ImageFile != null && owner.ImageFile.Length > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(owner.ImageFile.FileName);
                string extension = Path.GetExtension(owner.ImageFile.FileName);
                fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await owner.ImageFile.CopyToAsync(stream);
                }

                owner.OwernerImage = "/images/" + fileName;
            }
            if (owner.OwnerID > 0)
            {
                owner.UpdatedDate = DateTime.Now;
                success = await _repository.UpdateOwnerAsync(owner);
                owner = obj;

            }
            else
            {
                owner.CreatedDate = DateTime.Now;
                owner.UpdatedDate = DateTime.Now;
                success = await _repository.CreateOwnerAsync(owner);
                //owner= obj;

            }
            if (success)
            {
                return RedirectToAction("Create",new {id=0});
            }
            else
            {
                return View(owner);
            }
            //return success ? RedirectToAction("Create") : View(owner);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var owner = await _repository.GetOwnerByIdAsync(id);
            return View(owner);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(OwnerInfo owner)
        {
            if (!ModelState.IsValid)
                return View(owner);

            if (owner.ImageFile != null && owner.ImageFile.Length > 0)
            {
                string fileName = Path.GetFileNameWithoutExtension(owner.ImageFile.FileName);
                string extension = Path.GetExtension(owner.ImageFile.FileName);
                fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await owner.ImageFile.CopyToAsync(stream);
                }

                owner.OwernerImage = "/images/" + fileName;
            }

            owner.UpdatedDate = DateTime.Now;
            var success = await _repository.UpdateOwnerAsync(owner);
            return success ? RedirectToAction("Index") : View(owner);
       
        }


        public async Task<IActionResult> Delete(int id)
        {
            var owner = await _repository.GetOwnerByIdAsync(id);
            return View(owner);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var success = await _repository.DeleteOwnerAsync(id);
            return success ? RedirectToAction("Index") : NotFound();
        }
    }

}
