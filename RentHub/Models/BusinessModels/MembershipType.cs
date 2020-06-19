using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentHub.Models.BusinessModels
{
    public class MembershipType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Sign Up Fee")]
        public short SignUpFee { get; set; }

        [Display(Name = "Discount Rate")]
        public byte DiscountRate { get; set; }

        [Display(Name = "Duration In Months")]
        public byte DurationInMonths { get; set; }

        public static readonly byte Unknown = 0;

        public static readonly byte PayAsYouGo = 1;


    }
}