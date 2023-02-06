using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace MovieTheater.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        public ICollection<ClientShowTime> ClientShowTimes { get; set; }

        public Client(string firstName, string lastName, DateTime dateOfBirth, string username, string password)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Username = username;
            Password = password;
            ClientShowTimes = new List<ClientShowTime>();
        }
        public Client()
        {
            Id = Guid.NewGuid();
            ClientShowTimes = new List<ClientShowTime>();
        }
    }
}