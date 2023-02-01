using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
	public interface IShowtimeRepository
	{
		public Task<IEnumerable<ShowTime>> GetAllByCinemaIdAsync(string? id);
		public Task<ShowTime> GetShowtimeByCinemaIdAsync(string? id);
	}
}
