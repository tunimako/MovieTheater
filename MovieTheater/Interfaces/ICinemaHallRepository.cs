using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
	public interface ICinemaHallRepository
	{
		public List<CinemaHall> GetAllCinemaHalls(string? id);
	}
}
