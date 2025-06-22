using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models
{
    public class UserInfo:IdentityUser
    {
        public bool IsSuccess { get; set; }        
        public string? UserId { get; set; }
        [Required]
        [DisplayName("User Name")]
        [MaxLength(500)]
        public string? UserName { get; set; }
        [Required]
        [DisplayName("First Name")]
        [MaxLength(50)]
        public string? UserFirstName { get; set; }
        [DisplayName("Middle Name")]
        [MaxLength(50)]
        public string UserMiddleName { get; set; }
        [DisplayName("Last Name")]
        [MaxLength(50)]
        public string UserLastName { get; set; }
        [Required]
        [DisplayName("Full Name")]
        [MaxLength(100)]
        public string FullName { get; set; }
        [Required]
        [DisplayName("Email")]
        public string? UserEmail { get; set; }
        [Required]
        [DisplayName("Phone Number")]
        public string? UserPhone { get; set; }
        public int UserType { get; set; }  
        public int IsUserActive { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string UserPassword { get; set; } 
        [Required]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Passwords do not match.")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
