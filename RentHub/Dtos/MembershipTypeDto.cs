using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RentHub.Dtos
{
    public class MembershipTypeDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public short SignUpFee { get; set; }

        public byte DiscountRate { get; set; }

        public byte DurationInMonths { get; set; }
    }
}