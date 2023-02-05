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
        public async Task<bool> Add(ClientShowTime clientShowtime)
		{
			_context.Add(clientShowtime);
            return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
		}
	}
}
