using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeRentTracker.Models.OwnerEntity
{
    public class OwnerInfo
    {
        [Key]
        [Display(Name = "Owner ID")]
        public int? OwnerID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public string OwnerName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string OwnerEmail { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        [Display(Name = "Phone")]
        public string OwnerPhone { get; set; }
        [Required(ErrorMessage = "NID is required")]
        [Display(Name = "NID")]
        public string OwnerNID { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string OwnerAddress { get; set; }

        // public string OwernerPassword { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? OwernerImage { get; set; }
        [Required(ErrorMessage = "Created Date is required")]
        [Display(Name ="Make Date")]
        public DateTime CreatedDate { get; set; }
        [Required(ErrorMessage = "Updated Date is required")]
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }
        public bool IsActive{ get; set;}
    }
}
