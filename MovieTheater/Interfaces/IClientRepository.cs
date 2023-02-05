using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetAllClientsAsync();
        public Task<IEnumerable<Client>> GetClientsByCinemaAsync();
        public Task<Client> GetClientByCredentialsAsync(string username, string password);
        public Task<Client> GetClientByIdAsync(string id);
        bool Add(Client client);
        bool Update(Client client);
        bool Delete(Client client);
        bool Save();
    }
}
