using System.ComponentModel.DataAnnotations;

namespace AppDataIntigrity.Models
{
    public class CustomerViewModel
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
