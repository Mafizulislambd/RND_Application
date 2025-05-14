using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.LoginEntity
{
    public class LoginModel
    {

        [DisplayName("User ID")]
        [Required]
        public string userID { get; set; }
        [DisplayName("Password")]
        [Required]
        public string userPassword { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
