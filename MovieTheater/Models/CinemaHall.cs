using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace MovieTheater.Models
{
    public class CinemaHall
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Cinema")]
        public Guid CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public int AvailableSeats {get; set; }
        public ICollection<ShowTime> ShowTimes { get; set; }

        public CinemaHall(int availableSeats)
        {
            Id = Guid.NewGuid();
            AvailableSeats = availableSeats;
            ShowTimes = new List<ShowTime>();
        }
    }
}