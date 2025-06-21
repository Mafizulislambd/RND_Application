using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeRentTracker.Models.FlatInfo
{
    public class FlatInfoViewModel
    {
        public int Id { get; set; }
        public string RoadNo { get; set; }
        public string? BlockNo { get; set; }
        public string? BuildingNo { get; set; }
        public string FlatNo { get; set; }
        public string PlaceName { get; set; }

        public string PostOfficeId { get; set; }
        public string SubDistrictId { get; set; }
        public string DistrictId { get; set; }
        public string DivisionId { get; set; }
        public string CountryId { get; set; }
        //public FlatInformation? FlatInformation { get; set; }
        public List<SelectListItem> PostOffices { get; set; } = new();
        public List<SelectListItem> SubDistricts { get; set; } = new();
        public List<SelectListItem> Districts { get; set; } = new();
        public List<SelectListItem> Divisions { get; set; } = new();
        public List<SelectListItem> Countries { get; set; } = new();
    }
}
