using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using RentHub.Models;

namespace RentHub.ViewModels
{
    public class MembershipTypeViewModel
    {
        public MembershipType MembershipType { get; set; }

        public string Title
        {
            get
            {
                if (MembershipType != null && MembershipType.Id != 0)
                    return "Edit Membership Type";

                return "New Membership Type";
            }
        }
    }
}