using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentHub.Models;
using RentHub.Models.BusinessModels;

namespace RentHub.ViewModels
{
    public class CustomerViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }

    }
}