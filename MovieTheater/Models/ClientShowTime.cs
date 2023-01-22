using System.ComponentModel.DataAnnotations.Schema;

namespace MovieTheater.Models
{
    public class ClientShowTime
    {
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        [ForeignKey("ShowTime")]
        public int ShowTimeId { get; set; }
        public Client Client { get; set; }
        public ShowTime ShowTime { get; set; }
    }
}
