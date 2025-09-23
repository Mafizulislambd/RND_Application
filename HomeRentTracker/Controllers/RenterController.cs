using HomeRentTracker.Models.RenterEntity;
using HomeRentTracker.Services.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HomeRentTracker.Controllers
{

    public class RenterController : Controller
    {
        private readonly IRenterInfoContract _service;
        private string ImagePath;

        public RenterController(IRenterInfoContract service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var renters = await _service.GetAllAsync();
            return View(renters);
        }


        public   IActionResult Create(int id)
        {
            RenterInfo objRenterInfo = new RenterInfo();
           
            if (id > 0)
            {
                objRenterInfo =  _service.GetByIdAsync(id).Result;
            }
            //var model = new RenterInfo
            //{
            //  //  RenterName = "Default Name", // ✅ Set required property
            //   // RenterPhone = "000-000-0000", // ✅ Set required property
            //    MemberInfo = new MemberInfo(), // Ensure it's not null
            //    MemberInfoList = new List<MemberInfo>(),
            //    RenterList = renters?.ToList() // Fetch existing renters for the dropdown

            //};
            objRenterInfo.RenterList = _service.GetAllAsync().Result.ToList();
            return View(objRenterInfo); // Pass the model to the view
        }
        [HttpPost]
        public IActionResult AddMember(RenterInfo renter)
        {
            //// Add the new member to the list
            //if (renter.MemberInfo != null)
            //{
            //    renter.MemberInfoList.Add(renter.MemberInfo);
            //    renter.MemberInfo = new MemberInfo(); // Reset input
         
            //}
            //ModelState.Clear();
            //renter.RenterList = _service.GetAllAsync().Result.ToList();
            //return View("Create", renter);


            if (renter.MemberInfoList == null)
            {
                renter.MemberInfoList = new List<MemberInfo>();
            }

            // Add the new member to the list
            if (renter.MemberInfo != null)
            {
                renter.MemberInfoList.Add(renter.MemberInfo);
                renter.MemberInfo = new MemberInfo(); // Reset input
            }

            ModelState.Clear();
            renter.RenterList = _service.GetAllAsync().Result?.ToList() ?? new List<RenterInfo>();
            return View("Create", renter);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RenterInfo renter)
        {
            int renterID;
            if (ModelState.IsValid)
            {
                if (renter.ImageFile != null && renter.ImageFile.Length > 0)
                {

                    string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(renter.ImageFile.FileName);

                    string imageFile = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/");
                    Directory.CreateDirectory(imageFile);

                    string filePath = Path.Combine(imageFile, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        renter.ImageFile.CopyToAsync(stream);
                    }
                    renter.RenterImage = "images/" + uniqueFileName;


                    //string fileName = Path.GetFileNameWithoutExtension(owner.ImageFile.FileName);
                    //string extension = Path.GetExtension(owner.ImageFile.FileName);
                    //fileName = fileName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + extension;
                    //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/", fileName);

                    //using (var stream = new FileStream(path, FileMode.Create))
                    //{
                    //    await owner.ImageFile.CopyToAsync(stream);
                    //}

                    //owner.OwernerImage = "/images/" + fileName;


                }
                renterID = await _service.AddAsync(renter);
                return RedirectToAction("Create",0);
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
        public void DeleteImageFromServer(string relativePath)
        {
            if (!string.IsNullOrEmpty(relativePath))
            {
                string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", relativePath);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var renter = await _service.GetByIdAsync(id);
            ImagePath = renter.RenterImage;
            if (renter == null) return NotFound();
            return View(renter);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            // Delete the image file from the server
            DeleteImageFromServer(string.IsNullOrEmpty(ImagePath) ? string.Empty : ImagePath);
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
