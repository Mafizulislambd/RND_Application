using Microsoft.AspNetCore.Mvc.Rendering;

namespace HomeRentTracker.Models.Owner
{
    public class OwnerFilterViewModel
    {
        public string SearchText { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortColumn { get; set; } = "OwnerID";
        public string SortDirection { get; set; } = "DESC";
        public string? OwernerImage { get; set; }
        public DateTime? CreatedDateFrom { get; set; }
        public DateTime? CreatedDateTo { get; set; }
        public bool IsExport { get; set; } = false;
        public List<OwnerInfo> Owners { get; set; } = new List<OwnerInfo>();
        public int TotalCount { get; set; }
    }

}
