using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.CommonEntity
{
    public enum MaritalStatus
    {
        [Display(Name = "Single")]
        Single = 1,

        [Display(Name = "Married")]
        Married = 2,

        [Display(Name = "Divorced")]
        Divorced = 3,

        [Display(Name = "Widowed")]
        Widowed = 4,

        [Display(Name = "Separated")]
        Separated = 5,

        [Display(Name = "Other")]
        Other = 6
    }

}
