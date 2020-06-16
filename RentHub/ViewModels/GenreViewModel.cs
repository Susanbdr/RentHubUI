using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentHub.Models;

namespace RentHub.ViewModels
{
    public class GenreViewModel
    {
        public Genre Genre { get; set; }

        public string Title
        {
            get
            {
                if (Genre != null && Genre.Id != 0)
                    return "Edit Genre";

                return "New Genre";
            }
        }
    }
}