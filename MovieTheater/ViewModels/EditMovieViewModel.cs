using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieTheater.Data.Enums;
using MovieTheater.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MovieTheater.ViewModels
{
    public class EditMovieViewModel
    {
        public Guid Id { get; set; }
        [StringLength(50, ErrorMessage = "Name length can't be more than 50.")]
        [Required]
        public string Name { get; set; }
        public ICollection<MovieGenre>? MovieGenres { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, 10)]
        [Required]
        public double Rating { get; set; }
        [Required]
        public AgeRating AgeRating { get; set; }
        [Required]
        public TimeSpan Duration { get; set; }
        public ICollection<ShowTime>? ShowTimes { get; set; }
        public ICollection<EditMovieGenreViewModel> MovieGenresCheckBox { get; set; } = new List<EditMovieGenreViewModel>();
        [Required]
        public List<string>? CheckedMovieGenres { get; set; }
    }
}
