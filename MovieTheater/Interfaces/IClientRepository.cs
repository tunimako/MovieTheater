using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Cinema>> GetAllCinemas();
        public Task<Cinema> GetCinemaById(string? id);
        public Task<IEnumerable<ShowTime>> GetAllShowTimesByCinema(Cinema cinema);
        public Task<Client> GetClientByIdAsync(string? id);
        bool Add(Client client);
        bool Update(Client client);
        bool Delete(Client client);
        bool Save();
    }
}
