using HomeRentTracker.Models.FlatInfoEntity;
using HomeRentTracker.Services.Contract;
using HomeRentTracker.Services.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeRentTracker.Controllers
{
    public class FlatInfoController : Controller
    {
        private readonly IFlatInfo _flatInfo;
        private readonly ILocationService _locationService;

        public FlatInfoController(IFlatInfo flatInfo, ILocationService locationService)
        {
            _flatInfo = flatInfo;
            _locationService = locationService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _flatInfo.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _flatInfo.GetByIdAsync(id);

            if (model == null)
                return NotFound();

            var viewModel = new FlatInfoViewModel
            {
                Id = model.Id,
                RoadNo = model.RoadNo,
                FlatNo = model.FlatNo,
                PlaceName = model.PlaceName,
                BuildingNo = model.BuildingNo,
                BlockNo = model.BlockNo,
                // ... other fields
                CountryId = model.CountryId,
                DivisionId = model.DivisionId,
                DistrictId = model.DistrictId,
                SubDistrictId = model.SubDistrictId,
                PostOfficeId = model.PostOfficeId,

                // Fetch dropdowns
                Countries = await _locationService.GetCountriesAsync(),
                Divisions = await _locationService.GetDivisionsByCountryIdAsync(int.Parse(model.CountryId)), // Fix: Convert string to int
                Districts = await _locationService.GetDistrictsByDivisionIdAsync(int.Parse(model.DivisionId)), // Fix: Convert string to int
                SubDistricts = await _locationService.GetSubDistrictsByDistrictIdAsync(int.Parse(model.DistrictId)), // Fix: Convert string to int
                PostOffices = await _locationService.GetPostOfficesBySubDistrictIdAsync(int.Parse(model.SubDistrictId)) // Fix: Convert string to int
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FlatInfoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var md = new FlatInformation
                {
                    Id = model.Id,
                    RoadNo = model.RoadNo,
                    FlatNo = model.FlatNo,
                    PlaceName = model.PlaceName,
                    BuildingNo = model.BuildingNo,
                    BlockNo = model.BlockNo,
                    // ... other fields
                    CountryId = model.CountryId,
                    DivisionId = model.DivisionId,
                    DistrictId = model.DistrictId,
                    SubDistrictId = model.SubDistrictId,
                    PostOfficeId = model.PostOfficeId,

                };
                await _flatInfo.UpdateAsync(md);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _flatInfo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _flatInfo.GetByIdAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            var model = new FlatInformation
            {
                Countries = await _locationService.GetCountriesAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlatInformation model)
        {
            if (ModelState.IsValid)
            {
                await _flatInfo.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> GetDivisions(int countryId)
        {
            var data = await _locationService.GetDivisionsByCountryIdAsync(countryId);
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDistricts(int divisionId)
        {
            var data = await _locationService.GetDistrictsByDivisionIdAsync(divisionId);
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetSubDistricts(int districtId)
        {
            var data = await _locationService.GetSubDistrictsByDistrictIdAsync(districtId);
            return Json(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetPostOffices(int subDistrictId)
        {
            var data = await _locationService.GetPostOfficesBySubDistrictIdAsync(subDistrictId);
            return Json(data);
        }

    }
}
