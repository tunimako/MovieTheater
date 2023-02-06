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
                                           .Include(c => c.Cinema)
                                           .ThenInclude(ch1 => ch1.CinemaHalls).OrderBy(x => x.Id)
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
        public async Task<IEnumerable<ShowTime>> GetAllShowtimesAsync()
        {
            return await _context.ShowTimes.Include(ch => ch.CinemaHall)
                                           .ThenInclude(c => c.Cinema)
                                           .ThenInclude(ch1 => ch1.CinemaHalls)
                                           .Include(m => m.Movie)
                                           .Include(cl => cl.ClientShowTimes)
                                           .ToListAsync();
        }
        public async Task<ShowTime> GetShowtimeByIdAsync(string? id)
        {
            return await _context.ShowTimes.Include(x => x.Cinema)
                                           .FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }
        public bool Add(ShowTime showTime)
        {
            _context.Add(showTime);
            return Save();
        }
        public bool Delete(ShowTime showtime)
        {
            _context.Remove(showtime);
            return Save();
        }
        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }
    }
}
