using System;
using System.ComponentModel.DataAnnotations;

namespace RentHub.Models.BusinessModels
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe To Newsletter")]
        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public string DateOfBirthForDisplay => Convert.ToString($"{DateOfBirth:dd/MM/yyyy}");

      
    }
}