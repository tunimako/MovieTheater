using MovieTheater.Models;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.ViewModels
{
	public class ClientViewModel
	{
		public Client? Client { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
		public string CinemaId { get; set; }
		public IEnumerable<Cinema>? Cinemas { get; set; }
	}
}
