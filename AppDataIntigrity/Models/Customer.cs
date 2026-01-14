using System.ComponentModel.DataAnnotations;

namespace AppDataIntigrity.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
