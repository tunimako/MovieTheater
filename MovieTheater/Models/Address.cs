using System.ComponentModel.DataAnnotations;

namespace MovieTheater.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string Country { get; set; }

        public Address(string city, string street, string buildingNumber,string country)
        {
            Id = Guid.NewGuid();
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
            Country = country;
        }
    }
}
