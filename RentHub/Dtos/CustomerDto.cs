using System;
using System.ComponentModel.DataAnnotations;

namespace RentHub.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

    }
}