using HomeRentTracker.Models.Enumation;
using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.RenterEntity
{
    public class MemberInfo
    {
        [Key]
        public int MemberId { get; set; }
        [Display(Name = "Name")]
        public string MemberName { get; set; } = string.Empty;
        [Display(Name = "Age")]
        public int? MemberAge { get; set; }
        [Display(Name = "Phone")]
        public string MemberPhone { get; set; } = string.Empty;
        [Display(Name = "Email")]
        public string? MemberEmail { get; set; }
        [Display(Name = "National ID")]
        public string MemberNID { get; set; } = string.Empty;
        [Display(Name = "Address")]
        public string? MemberAddress { get; set; }
        [Display(Name = "Profession")]
        public Profession MemberProfession { get; set; }
        //    public string MemberProfession { get; set; } = string.Empty;
        [Display(Name = "Guardian ID")]
        public string GuardianID { get; set; } = string.Empty;
        [Display(Name = "Guardian NID")]
        public string? GuardialNID { get; set; }
        public string? RelationWithGuardian { get; set; }
    }
}
