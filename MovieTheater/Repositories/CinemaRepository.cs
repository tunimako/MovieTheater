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
                                         .Include(ch => ch.CinemaHalls)
                                         .ToListAsync();
        }
    }
}
