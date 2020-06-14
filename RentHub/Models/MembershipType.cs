using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentHub.Models
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


    }
}