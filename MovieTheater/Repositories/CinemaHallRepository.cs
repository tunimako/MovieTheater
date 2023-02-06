using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repositories
{
	public class CinemaHallRepository : ICinemaHallRepository
	{
		private readonly MovieTheaterDbContext _context;

		public CinemaHallRepository(MovieTheaterDbContext context)
		{
			_context = context;
		}

		public List<CinemaHall> GetAllCinemaHalls(string? id)
		{
			return _context.CinemaHalls.Include(sh => sh.ShowTimes)
									   .Where(x => x.CinemaId.ToString() == id)
									   .ToList();
		}
	}
}
