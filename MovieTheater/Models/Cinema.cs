using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class Cinema
    {
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [ForeignKey("Address")]
        public Guid AddressId { get; set; }
        public Address Address { get; set; }
        public int OpenTimeHour { get; set; }
        public int OpenTimeMinutes { get; set; }
        public int CloseTimeHour { get; set; }
        public int CloseTimeMinutes { get; set; }
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<CinemaHall> CinemaHalls { get; set; }
        public ICollection<ShowTime> ShowTimes { get; set; }

        public Cinema(string name, int openTimeHour, int openTimeMinutes, int closeTimeHour, int closeTimeMinutes)
        {
            Id = Guid.NewGuid();
            Name = name;
            OpenTimeHour = openTimeHour;
            OpenTimeMinutes = openTimeMinutes;
            CloseTimeHour = closeTimeHour;
            CloseTimeMinutes = closeTimeMinutes;
            CinemaHalls = new List<CinemaHall>();
            ShowTimes = new List<ShowTime>();
        }
    }
}
