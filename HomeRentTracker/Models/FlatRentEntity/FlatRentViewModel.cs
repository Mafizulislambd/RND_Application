using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeRentTracker.Models.FlatRentEntity
{
    public class FlatRentViewModel
    {
        public FlatRent Flat { get; set; }
        public string? OwenerName { get; set; }
        public List<SelectListItem>? OwnerList { get; set; }
        public List<SelectListItem>? FlatList { get; set; }
    }
}
