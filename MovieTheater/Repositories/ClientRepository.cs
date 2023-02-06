using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly MovieTheaterDbContext _context;

        public ClientRepository(MovieTheaterDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Client>> GetClientsByCinemaAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Client> GetClientByCredentialsAsync(string username, string password)
        {
            return await _context.Clients.Include(csh => csh.ClientShowTimes)
                                         .ThenInclude(s => s.ShowTime)
                                         .ThenInclude(s => s.CinemaHall)
                                         .ThenInclude(s => s.Cinema)
                                         .FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
        }
        public async Task<Client> GetClientByIdAsync(string? id)
        {
            return await _context.Clients.Include(sh => sh.ClientShowTimes)
                                         .FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }
        public bool Add(Client client)
        {
            _context.Add(client);
            return Save();
        }
        public bool Delete(Client client)
        {
            _context.Remove(client);
            return Save();
        }
        public bool Update(Client client)
        {
            _context.Update(client);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
