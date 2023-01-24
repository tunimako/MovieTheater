using MovieTheater.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class MovieGenre
    {  
        public Guid Id { get; set; }
        [ForeignKey("Movie")]
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
        [EnumDataType(typeof(Genre))]
        public Genre Genre { get; set; }

        public MovieGenre(Genre genre)
        {
            Id = Guid.NewGuid();
            Genre = genre;
        }
    }
}
