using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
	public interface IShowtimeRepository
	{
		public Task<IEnumerable<ShowTime>> GetAllByCinemaIdAsync(string? id);
		public Task<ShowTime> GetShowtimeByCinemaIdAsync(string? id);
		public Task<ShowTime> GetShowtimeByIdAsync(string? id);
		public bool Add(ShowTime showtime);
		public bool Delete(ShowTime showtime);
		public bool Save();
	}
}
