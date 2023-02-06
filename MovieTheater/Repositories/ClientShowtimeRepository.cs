using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repositories
{
    public class ClientShowtimeRepository : IClientShowtimeRepository
    {
        private readonly MovieTheaterDbContext _context;

        public ClientShowtimeRepository(MovieTheaterDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientShowTime>> GetAllByClientIdAsync(string? id)
        {
            return await _context.ClientShowTimes.Where(x => x.ClientId.ToString() == id)
                                                 .ToListAsync();
        }
        public async Task<bool> Add(ClientShowTime clientShowtime)
        {
            _context.Add(clientShowtime);
            return Save();
        }
        public bool Delete(ClientShowTime clientShowtime)
        {
            _context.ClientShowTimes.Remove(clientShowtime);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}