namespace HomeRentTracker.Models.RenterEntity
{
    public class RenterInfo
    {
        public int RenterID { get; set; }
        public string GuradianName { get; set; }
        public string GuradianPhone { get; set; }
        public string? GuradianEmail { get; set; }
        public string? GuardialNID { get; set; }
        public string GuardialProfession { get; set; }
        public string? GuradianAddress { get; set; }
        public  string RenterName { get; set; }
        public string RenterPhone { get; set; }
        public string? RenterEmail { get; set; }
        public string RenterNID { get; set; }
        public string? RenterAddress { get; set; }
        public int TotalMember { get; set; }
        public List<MemberInfo> MemberInfo { get; set; } = new();


    }
}
