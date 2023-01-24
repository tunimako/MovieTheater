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

        public async Task<IEnumerable<Cinema>> GetAllCinemas()
        {
            return await _context.Cinemas.ToListAsync();
        }
        public async Task<IEnumerable<ShowTime>> GetAllShowTimesByCinema(Cinema cinema)
        {
            return await _context.ShowTimes.Where(x => x.Cinema == cinema).ToListAsync();
        }
        public async Task<Cinema> GetCinemaById(string id)
        {
            return await _context.Cinemas.FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }
        public async Task<Client> GetClientByIdAsync(string id)
        {
            return await _context.Clients.FirstOrDefaultAsync(x => x.Id.ToString() == id);
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
