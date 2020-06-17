﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RentHub.Models;

namespace RentHub.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(1, 20, ErrorMessage = "Number must be between 1 to 20")]
        public byte NumberInStock { get; set; }

    }
}