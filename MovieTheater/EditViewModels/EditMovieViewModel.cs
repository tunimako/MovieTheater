using MovieTheater.Data.Enums;
using MovieTheater.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieTheater.EditViewModels
{
    public class EditMovieViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<MovieGenre>? MovieGenres { get; set; }
        public string? Description { get; set; }
        public double Rating { get; set; }
        public AgeRating AgeRating { get; set; }
        public TimeSpan Duration { get; set; }
        public ICollection<ShowTime>? ShowTimes { get; set; }
        public ICollection<EditMovieGenreViewModel> MovieGenresCheckBox { get; set; } = new List<EditMovieGenreViewModel>();
        public List<string>? CheckedMovieGenres { get; set; }
    }
}
