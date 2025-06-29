using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.CommonEntity
{
    public enum ReligionEntity
    {

        [Display(Name = "Islam")]
        Islam = 1,

        [Display(Name = "Hinduism")]
        Hinduism = 2,

        [Display(Name = "Christianity")]
        Christianity = 3,

        [Display(Name = "Buddhism")]
        Buddhism = 4,

        [Display(Name = "Sikhism")]
        Sikhism = 5,

        [Display(Name = "Judaism")]
        Judaism = 6,

        [Display(Name = "Atheism")]
        Atheism = 7,

        [Display(Name = "Agnosticism")]
        Agnosticism = 8,

        [Display(Name = "Other")]
        Other = 9
    }


}
