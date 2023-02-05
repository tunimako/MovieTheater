using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
	public interface IClientShowtimeRepository
	{
		public Task<bool> Add(ClientShowTime clientShowtime);
		public bool Save();
	}
}
