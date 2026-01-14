using System.ComponentModel.DataAnnotations;

namespace HomeRentTracker.Models.CommonEntity
{
    public enum RelationEntity
    {
        [Display(Name = "Father")]
        Father = 1,

        [Display(Name = "Mother")]
        Mother = 2,

        [Display(Name = "Spouse")]
        Spouse = 3,

        [Display(Name = "Brother")]
        Brother = 4,

        [Display(Name = "Sister")]
        Sister = 5,

        [Display(Name = "Son")]
        Son = 6,

        [Display(Name = "Daughter")]
        Daughter = 7,

        [Display(Name = "Friend")]
        Friend = 8,

        [Display(Name = "Colleague")]
        Colleague = 9,

        [Display(Name = "Relative")]
        Relative = 10,

        [Display(Name = "Neighbor")]
        Neighbor = 11,

        [Display(Name = "Other")]
        Other = 12
    }

}

