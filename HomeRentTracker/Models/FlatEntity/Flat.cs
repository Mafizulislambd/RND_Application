using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeRentTracker.Models.FlatEntity
{
    public class Flat
    {
        
        public int? FlatId { get; set; }
        [DisplayName("Flat No")]
        [Required]
        public string FlatNo { get; set; }
        [DisplayName("Owner")]
        [Required]
        public string?FlatOwener { get; set; }
        [DisplayName("Rent")]
        public double FlatRent { get; set; }
        [DisplayName("Rent Paid By")]
        [Required]
        public string RentPaidBy { get; set; }
        [DisplayName("Rent Receive")]
        public bool RentReceive { get; set; }
        [DisplayName("Rent Receiver Name")]
        [Required]
        public string? RentReceiverName { get; set; }
        [DisplayName("Receive Date")]
        public DateOnly ReceiveDate { get; set; }
        [DisplayName("Received Month")]
        public DateOnly RentMonth { get; set; }

    }
}
