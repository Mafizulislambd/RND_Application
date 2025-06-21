using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeRentTracker.Services.Contract
{
    public interface ILocationService
    {
        Task<List<SelectListItem>> GetCountriesAsync();
        Task<List<SelectListItem>> GetDivisionsByCountryIdAsync(int countryId);
        Task<List<SelectListItem>> GetDistrictsByDivisionIdAsync(int divisionId);
        Task<List<SelectListItem>> GetSubDistrictsByDistrictIdAsync(int districtId);
        Task<List<SelectListItem>> GetPostOfficesBySubDistrictIdAsync(int subDistrictId);
        //Task<List<SelectListItem>> GetPostOfficesAsync();
        //Task<List<SelectListItem>> GetSubDistrictsByPostOfficeIdAsync(int postOfficeId);
        //Task<List<SelectListItem>> GetDistrictsBySubDistrictIdAsync(int subDistrictId);
        //Task<List<SelectListItem>> GetDivisionsByDistrictIdAsync(int districtId);
        //Task<List<SelectListItem>> GetCountriesByDivisionIdAsync(int divisionId);

        //Task<string> GetPostOfficeName(int id);
        //Task<string> GetSubDistrictName(int id);
        //Task<string> GetDistrictName(int id);
        //Task<string> GetDivisionName(int id);
        //Task<string> GetCountryName(int id);
    }

}
