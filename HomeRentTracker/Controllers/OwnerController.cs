using HomeRentTracker.Models.Owner;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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



        [HttpPost]
        public async Task<IActionResult> Create(OwnerInfo owner) // This method is for handling form submission.
        {
            if (!ModelState.IsValid)
                return View(owner);

            owner.CreatedDate = DateTime.Now;
            owner.UpdatedDate = DateTime.Now;

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

            var success = await _repository.CreateOwnerAsync(owner);
            return success ? RedirectToAction("Index") : View(owner);
        }


      //  [HttpPost]
        //public async Task<IActionResult> Create(OwnerInfo owner)
        //{
        //    if (!ModelState.IsValid) return View(owner);
        //    owner.CreatedDate = DateTime.Now;
        //    owner.UpdatedDate = DateTime.Now;
        //    var success = await _repository.CreateOwnerAsync(owner);
        //    return success ? RedirectToAction("Index") : View(owner);
        //}
        [HttpGet]
        public IActionResult Create()
        {
            //var owners = _repository.GetOwnerList().Result; // Ensure the task is awaited or resolved
            //var viewModel = new OwnerFilterViewModel
            //{
            //    OwnerList = owners.Select(o => new SelectListItem
            //    {
            //        Value = o.OwnerID.ToString(),
            //        Text = o.OwnerName
            //    }).ToList()
            //};

            return View(); // Pass the viewModel to the view
        }

        public async Task<IActionResult> Edit(int id)
        {
            var owner = await _repository.GetOwnerByIdAsync(id);
            return View(owner);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(OwnerInfo owner)
        //{
        //    if (!ModelState.IsValid) return View(owner);
        //    owner.UpdatedDate = DateTime.Now;
        //    var success = await _repository.UpdateOwnerAsync(owner);
        //    return success ? RedirectToAction("Index") : View(owner);
        //}
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
