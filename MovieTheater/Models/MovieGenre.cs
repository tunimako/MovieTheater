using MovieTheater.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class MovieGenre
    {  
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        public Genre Genre { get; set; }

        public MovieGenre(Genre genre)
        {
            Genre = genre;
        }
    }
}
