using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentHub.Models;

namespace RentHub.Dtos
{
    public class CustomerDto
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

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

    }
}