using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter movie name")]
        [Display(Name = "Name movie")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter release date")]
        public DateTime ReleaseDate { get; set; }

        public Genre Genre { get; set; }

        [Required(ErrorMessage ="Please select the name of genre")]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage ="Please enter the number of stock")]
        [Display(Name = "Number in stock")]
        [Range(1, 200, ErrorMessage ="Number of stock should from 0 to 200")]
        public int NumInStock { get; set; }
    }
}