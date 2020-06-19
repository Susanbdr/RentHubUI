using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RentHub.Models;
using RentHub.Models.BusinessModels;

namespace RentHub.ViewModels
{
    public class MovieViewModel
    {
        public MovieViewModel()
        {
            Id = 0;
        }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            NumberAvailable = movie.NumberInStock;
        }

        public List<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number In Stock")]
        [Required]
        [Range(1, 20, ErrorMessage = "Number must be between 1 to 20")]
        public byte? NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

        public string Title => Id != 0 ? "Edit Movie" : "New Movie";
    }
}