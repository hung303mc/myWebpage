using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MoviesDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter movie name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter release date")]
        public DateTime ReleaseDate { get; set; }

        public GenreDto Genre { get; set; }

        [Required(ErrorMessage ="Please select the name of genre")]
        public int GenreId { get; set; }

        [Required(ErrorMessage ="Please enter the number of stock")]
        [Range(1, 200, ErrorMessage ="Number of stock should from 0 to 200")]
        public int NumInStock { get; set; }
    }
}