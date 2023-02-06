using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
	public interface IClientShowtimeRepository
	{
		public Task<IEnumerable<ClientShowTime>> GetAllByClientIdAsync(string? id);
		public Task<bool> Add(ClientShowTime clientShowtime);
		public bool Delete(ClientShowTime clientShowtime);
		public bool Save();
	}
}
