using MovieTheater.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.ViewModels
{
	public class CreateShowtimeViewModel
	{
		[Required]
		public string Id { get; set; } //Galbūt galime saugoti kaip stringą sudarytą iš filmo pavadinimo ir skaičiaus indikuojančiu, kelintas tai yra šio filmo sensas;
		[Required]
		public Guid MovieId { get; set; }
		[Required]
		public string CinemaHallId { get; set; }
		public Movie? Movie { get; set; }
		[Required]
        public DateTime Day { get; set; }
		[Required]
		public DateTime Time { get; set; }
        public ICollection<ClientShowTime>? ClientShowTimes { get; set; }
		public IEnumerable<Movie>? Movies { get; set; }
		public Cinema? Cinema { get; set; }
		
		public CreateShowtimeViewModel()
		{
			ClientShowTimes = new List<ClientShowTime>();
		}
	}
}
