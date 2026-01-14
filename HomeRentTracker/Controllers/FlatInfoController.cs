using HomeRentTracker.Models.FlatInfoEntity;
using HomeRentTracker.Services.Contract;
using HomeRentTracker.Services.Repos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeRentTracker.Controllers
{
    public class FlatInfoController : Controller
    {
        private readonly IFlatInfoContract _flatInfo;
        private readonly ILocationContract _locationService;

        public FlatInfoController(IFlatInfoContract flatInfo, ILocationContract locationService)
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
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _flatInfo.GetByIdAsync(id);
            return View(model);
        }
        public async Task<IActionResult> Create(int id)
        {
            FlatInformation flatInformation = new FlatInformation();
            if (id > 0)
            {
                var model1 = await _flatInfo.GetByIdAsync(id);
                if (model1 == null)
                    return NotFound();

                //var viewModel = new FlatInfoViewModel
                //{
                //    Id = model1.Id,
                //    RoadNo = model1.RoadNo,
                //    FlatNo = model1.FlatNo,
                //    PlaceName = model1.PlaceName,
                //    BuildingNo = model1.BuildingNo,
                //    BlockNo = model1.BlockNo,
                //    // ... other fields
                //    CountryId = model1.CountryId,
                //    DivisionId = model1.DivisionId,
                //    DistrictId = model1.DistrictId,
                //    SubDistrictId = model1.SubDistrictId,
                //    PostOfficeId = model1.PostOfficeId,

                //    // Fetch dropdownss
                //    Countries = await _locationService.GetCountriesAsync(),
                //    Divisions = await _locationService.GetDivisionsByCountryIdAsync(int.Parse(model1.CountryId)), // Fix: Convert string to int
                //    Districts = await _locationService.GetDistrictsByDivisionIdAsync(int.Parse(model1.DivisionId)), // Fix: Convert string to int
                //    SubDistricts = await _locationService.GetSubDistrictsByDistrictIdAsync(int.Parse(model1.DistrictId)), // Fix: Convert string to int
                //    PostOffices = await _locationService.GetPostOfficesBySubDistrictIdAsync(int.Parse(model1.SubDistrictId)) // Fix: Convert string to int
                //};
                model1.FlatInformations = await _flatInfo.GetAllAsync();
                model1.Countries = await _locationService.GetCountriesAsync();

                //flatInformation.DivisionId = await _locationService.GetDivisionsByCountryIdAsync(int.Parse(model1.CountryId)), // Fix: Convert string to int
                //    Districts = await _locationService.GetDistrictsByDivisionIdAsync(int.Parse(model1.DivisionId)), // Fix: Convert string to int
                //    SubDistricts = await _locationService.GetSubDistrictsByDistrictIdAsync(int.Parse(model1.DistrictId)), // Fix: Convert string to int
                //    PostOffices = await _locationService.GetPostOfficesBySubDistrictIdAsync(int.Parse(model1.SubDistrictId)) // Fix: Convert string to int
                flatInformation = model1;
            }
            else
            {
                var viewModel = new FlatInformation
                {
                    Countries = await _locationService.GetCountriesAsync(),
                    FlatInformations = await _flatInfo.GetAllAsync()
                };
                flatInformation = viewModel;
                return View(viewModel);
            }
            //var model = new FlatInformation
            //{
            //    Countries = await _locationService.GetCountriesAsync(),
            //    FlatInformations = await _flatInfo.GetAllAsync()
            //};
            return View(flatInformation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlatInformation model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    await _flatInfo.UpdateAsync(model);
                }
                else
                {

                    await _flatInfo.AddAsync(model);
                }
                model.FlatInformations = await _flatInfo.GetAllAsync();
                //return RedirectToAction("Create",model.Id=0);
            }
            return RedirectToAction("Create", new {id=0});
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
