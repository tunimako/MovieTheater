using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Company
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public ICollection<Cinema> Cinemas { get; set; }
        public Company()
        {
            Id = Guid.NewGuid();
            Name = "MovieForum";
            Owner = "CodeAcademy";
            Cinemas = new List<Cinema>();
        }
    }
}
