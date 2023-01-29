using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieTheater.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Genre")]
        public ICollection<MovieGenre> MovieGenres { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        [Display(Name = "Age rating")]
        public AgeRating AgeRating { get; set; } 
        public TimeSpan Duration { get; set; }
        public ICollection<ShowTime> ShowTimes { get; set; }

        public Movie(string name, string description, double rating, TimeSpan duration, AgeRating ageRating)
        {
            Id = Guid.NewGuid();
            Name = name;
            MovieGenres = new List<MovieGenre>();
            Description = description;
            Rating = rating;
            Duration = duration;
            AgeRating = ageRating;
            ShowTimes = new List<ShowTime>();
        }
        public Movie()
        {
            ShowTimes = new List<ShowTime>();
        }
    }
}