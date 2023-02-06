using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MovieTheater.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieTheater.ViewModels
{
	public class LoginViewModel
    {
        public string? CinemaId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<ClientShowTime>? ClientShowTimes { get; set; }
	}
}
