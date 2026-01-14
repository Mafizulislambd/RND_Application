using System.ComponentModel.DataAnnotations;

namespace AppDataIntigrity.Models
{
    public class AccountViewModel
    {
        [Required]
        public int CustomerId { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Initial balance must be non-negative.")]
        public decimal InitialBalance { get; set; }
    }

}
