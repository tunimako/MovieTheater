using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repositories
{
    public class CinemaRepository : ICinemaRepository
    {
        private readonly MovieTheaterDbContext _context;

        public CinemaRepository(MovieTheaterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cinema>> GetAll()
        {
            return await _context.Cinemas.Include(a => a.Address)
                                         .Include(c => c.Company)
                                         .Include(ch => ch.CinemaHalls).OrderBy(x => x.Id)
                                         .ToListAsync();
        }
        public async Task<Cinema> GetCinemaByIdAsync(string? id)
        {
            return await _context.Cinemas.Include(ch => ch.CinemaHalls)
                                         .ThenInclude(s => s.ShowTimes)
                                         .FirstOrDefaultAsync(c => c.Id.ToString() == id);
        }
        public Cinema GetCinemaById(string? id)
        {
            return _context.Cinemas.Include(ch => ch.CinemaHalls)
                                   .ThenInclude(s => s.ShowTimes)
                                   .ThenInclude(s => s.ClientShowTimes)
                                   .ThenInclude(s => s.Client)
                                   .FirstOrDefault(c => c.Id.ToString() == id);
        }
    }
}
