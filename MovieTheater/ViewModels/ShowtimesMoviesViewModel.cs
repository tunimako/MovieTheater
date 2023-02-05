using MovieTheater.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.ViewModels
{
    public class ShowtimesMoviesViewModel
    {
        public string Id { get; set; }
        public IEnumerable<ShowTime> Showtimes { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
        public Cinema Cinema { get; set; }
    }
}
