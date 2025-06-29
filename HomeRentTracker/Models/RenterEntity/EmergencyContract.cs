using HomeRentTracker.Models.CommonEntity;
using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.RenterEntity
{
    public class EmergencyContract
    {
        public int contractID { get; set; }
        [Display(Name = "Name")]
        public string? contractName { get; set; }
        [Display(Name = "Phone")]
        public string? contractPhone { get; set; }
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Display(Name = "Relation")]
        public RelationEntity? Relation { get; set; }
    }
}
