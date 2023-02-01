using MovieTheater.Models;

namespace MovieTheater.ViewModels
{
    public class ShowtimesMoviesViewModel
    {
        public IEnumerable<ShowTime> Showtimes { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}
