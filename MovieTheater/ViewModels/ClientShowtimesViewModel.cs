using MovieTheater.Models;

namespace MovieTheater.ViewModels
{
	public class ClientShowtimesViewModel
	{
		public string ClientId { get; set; }
		public string ShowtimeId { get; set; }
		public ClientViewModel? ClientViewModel { get; set; }
        public IEnumerable<ShowTime>? Showtimes { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
		public Cinema? Cinema { get; set; }
	}
}
