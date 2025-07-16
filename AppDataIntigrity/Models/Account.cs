using System.ComponentModel.DataAnnotations;

namespace AppDataIntigrity.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Balance { get; set; }

        public Customer Customer { get; set; }
    }

}
