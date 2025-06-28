using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.FlatInfoEntity
{
    public class FlatInformation
    {
        public int Id { get; set; }
        [Display(Name = "Road No")]
        public string RoadNo { get; set; }
        [Display(Name = "Block No")]
        public string? BlockNo { get; set; }
        [Display(Name = "Building No")]
        public string? BuildingNo { get; set; }
        [Display(Name = "Flat No")]
        public string FlatNo { get; set; }
        [Display(Name = "Place Name")]
        public string PlaceName { get; set; }
        [Display(Name = "Post Office")]
        public string PostOfficeId { get; set; }
        [Display(Name = "Sub District")]
        public string SubDistrictId { get; set; }
        [Display(Name = "District")]
        public string? DistrictId { get; set; }
        [Display(Name = "Division")]
        public string? DivisionId { get; set; }
        [Display(Name = "Country")]
        public string? CountryId { get; set; }
        public List<SelectListItem> Countries { get; set; } = new();


    }
}
