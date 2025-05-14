using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.LoginEntity
{
    public class LoginViewModel
    {
        [Required]
        public string userID { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
