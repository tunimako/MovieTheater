using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repositories
{
	public class ShowtimeRepository : IShowtimeRepository
	{
		private readonly MovieTheaterDbContext _context;

		public ShowtimeRepository(MovieTheaterDbContext context)
		{
			_context = context;
		}

        public async Task<ShowTime> GetShowtimeByCinemaIdAsync(string? id)
        {
            return await _context.ShowTimes.Include(ch => ch.CinemaHall)
                                           .ThenInclude(c => c.Cinema)
                                           .ThenInclude(ch1 => ch1.CinemaHalls)
                                           .FirstOrDefaultAsync(x => x.CinemaId.ToString() == id);
        }

        public async Task<IEnumerable<ShowTime>> GetAllByCinemaIdAsync(string? id)
        {
            return await _context.ShowTimes.Include(ch => ch.CinemaHall)
                                           .ThenInclude(c => c.Cinema)
                                           .ThenInclude(ch1 => ch1.CinemaHalls)
                                           .Include(m => m.Movie)
                                           .Include(cl => cl.ClientShowTimes)
                                           .Where(x => x.CinemaHall.CinemaId.ToString() == id)
                                           .ToListAsync();
        }
    }
}
