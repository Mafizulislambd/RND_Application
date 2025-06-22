using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeRentTracker.Models.FlatEntity
{
    public class FlatViewModel
    {
        public Flat Flat { get; set; }
        public string? OwenerName { get; set; }
        public List<SelectListItem>? OwnerList { get; set; }
    }
}
