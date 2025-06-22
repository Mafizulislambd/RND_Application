using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.LoginEntity
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="User Name")]        
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string userPassword { get; set; } 
        public bool RememberMe { get; set; }
    }
}
