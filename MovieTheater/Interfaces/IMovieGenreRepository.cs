using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
	public interface IMovieGenreRepository
	{
		Task<IEnumerable<MovieGenre>> GetMovieGenresByMovieId(string? Id);
		bool DeleteMovieGenres(ICollection<MovieGenre> oldMovieGenres);
		bool Add(MovieGenre movieGenre);
        bool Update(MovieGenre movieGenre);
        bool Delete(MovieGenre movieGenre);
        bool Save();
	}
}
