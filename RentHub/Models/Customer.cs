using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentHub.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }
 
        [StringLength(255)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }

        public string ReturnCustomerFullNameForDisplay => FirstName + " " + MiddleName + " " + LastName;

        public string DateOfBirthForDisplay => Convert.ToString($"{DateOfBirth:dd/MM/yyyy}");
    }
}