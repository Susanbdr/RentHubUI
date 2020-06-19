using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations.Model;
using Microsoft.Ajax.Utilities;

namespace RentHub.Models.BusinessModels
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; private set; } = DateTime.Now; 

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "Number must be between 1 to 20")]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }


        public string ReleaseDateForDisplay => Convert.ToString($"{ReleaseDate:dd/MM/yyyy}");

    }
}