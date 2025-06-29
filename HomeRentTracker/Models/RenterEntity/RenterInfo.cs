using HomeRentTracker.Models.CommonEntity;
using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.RenterEntity
{
    public class RenterInfo
    {
        public int RenterID { get; set; }
        [Display(Name ="Renter Name")]
        public  string? RenterName { get; set; }
        public string? RenterImage { get; set; }

        [Display(Name = "Father Name")]
        public string? RenterFatherName { get; set; }
        [Display(Name = "Mother Name")]
        public string? RenterMotherName { get; set; }
        [Display(Name = "Date Of Birth")]
        public DateTime? RenterDOB { get; set; }
        [Display(Name = "Maritial Status")]
        public MaritalStatus RenterMaritialStatus { get; set; }     
        [Display(Name = "Address")]
        public string? RenterAddress { get; set; }
        [Display(Name = "Profession")]
        public Profession? RenterProfession { get; set; }
        [Display(Name = "Office Address")]
        public string? OfficeAddress { get; set; }
        [Display(Name = "Religion")]
        public ReligionEntity? Religion { get; set; }
        [Display(Name = "Educational Background")]
        public string? EducationalBackground { get; set; }

        [Display(Name = "Phone")]
        public  string? RenterPhone { get; set; }
        [Display(Name = "Email")]
      //  [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid Email format.")]
        public string? RenterEmail { get; set; }
        [Display(Name = "National ID")]
      //  [RegularExpression(@"^\d{10,17}$", ErrorMessage = "Invalid NID format. It should be 10 to 17 digits.")]
        public string? RenterNID { get; set; }
        [Display(Name = "Passport No(If Exist)")]
        //[RegularExpression(@"^[A-Z]{1,2}\d{6,9}$", ErrorMessage = "Invalid Passport Number format.")]
        public string? PassportNo { get; set; }
        [Display(Name = "Emergency Contact Name")]
        public EmergencyContract? EmergencyContact { get; set; }
        public MemberInfo? MemberInfo { get; set; } = new MemberInfo();
        public List<MemberInfo>? MemberInfoList { get; set; } = new List<MemberInfo>();
        [Display(Name ="Member Name")]
        public  string? MemberName { get; set; }
        [Display(Name ="Member NID")]
        public string? MemberNID { get; set; }
        [Display(Name = "Member Phone")]
       // [RegularExpression(@"^\+?\d{10,15}$", ErrorMessage = "Invalid phone number format.")]
        public string? MemberPhone { get; set; }
        [Display(Name = "Membar Address")]
        public string? MemberAddress { get; set; }
        [Display(Name = "Member Email")]
        public string? MemberEmail{ get; set; }
        [Display(Name = "Driver Name")]
        public string? DriverName { get; set; }
        [Display(Name = "Driver NID")]
        public string? DriverNID { get; set; }
        [Display(Name = "Driver Phone")]
        public string? DriverPhone { get; set; }
        [Display(Name = "Driver Address")]
        public string? DriverAddress { get; set; }
        public int? TotalMember { get; set; }     
        public List<RenterInfo>? RenterList { get; set; } = new List<RenterInfo>();
    }
}
