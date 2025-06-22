using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.RenterEntity
{
    public class MemberInfo
    {
        [Key]
        public int MemberId { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public int MemberAge { get; set; }
        public string MemberPhone { get; set; } = string.Empty;
        public string? MemberEmail { get; set; }
        public string MemberNID { get; set; } = string.Empty;
        public string? MemberAddress { get; set; }
        public string MemberProfession { get; set; } = string.Empty;
        public string GuardianID { get; set; } = string.Empty;
        public string? GuardialNID { get; set; }
        public string? RelationWithGuardian { get; set; }
    }
}
