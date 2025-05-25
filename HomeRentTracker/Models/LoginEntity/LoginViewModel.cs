using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.LoginEntity
{
    public class LoginViewModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string userPassword { get; set; } 
        public bool RememberMe { get; set; }
    }
}
