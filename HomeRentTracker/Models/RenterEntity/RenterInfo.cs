using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.RenterEntity
{
    public class RenterInfo
    {
        public int RenterID { get; set; }
        [Display(Name ="Renter Name")]
        public required string RenterName { get; set; }
        [Display(Name = "Phone")]
        public required string RenterPhone { get; set; }
        [Display(Name = "Email")]
        public string? RenterEmail { get; set; }
        [Display(Name = "National ID")]
        public string? RenterNID { get; set; }
        [Display(Name = "Profession")]
        public string? RenterProfession { get; set; }
        [Display(Name = "Address")]
        public string? RenterAddress { get; set; }
        [Display(Name ="Member Name")]
        public  string? MemberName { get; set; }
        [Display(Name = "Member Phone")]
        public string? MemberPhone { get; set; }
        [Display(Name = "Member Email")]
        public string? MemberEmail{ get; set; }
        [Display(Name = "Membar Email")]
        public string? MemberNID { get; set; }
        [Display(Name = "Membar Address")]
        public string? MemberAddress { get; set; }
        public int? TotalMember { get; set; }      
        //public  string? RenterName { get; set; }
        //public string? RenterPhone { get; set; }
        //public string? RenterEmail { get; set; }
        //public string? RenterNID { get; set; }
        //public string? RenterAddress { get; set; }
        //public int TotalMember { get; set; }
        public List<MemberInfo> MemberInfo { get; set; } = new();


    }
}
