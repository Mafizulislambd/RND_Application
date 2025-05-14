using System.ComponentModel.DataAnnotations;

namespace FlatRentTracker.Models
{
    public class LoginViewModel
    {
        [Required]
        public string userID { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
