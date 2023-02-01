using MovieTheater.Models;

namespace MovieTheater.ViewModels
{
	public class CreateShowtimeViewModel
	{
		public ShowTime Showtime { get; set; }
		public IEnumerable<Movie> Movies { get; set; }
	}
}
