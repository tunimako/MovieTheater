using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Repositories
{
	public class MovieGenreRepository : IMovieGenreRepository
	{
		private readonly MovieTheaterDbContext _context;

		public MovieGenreRepository(MovieTheaterDbContext context)
		{
			_context = context;
		}

        public async Task<IEnumerable<MovieGenre>> GetMovieGenresByMovieId(string? Id)
        {
            return await _context.MoviesGenres.Where(x => x.MovieId.ToString() == Id).ToListAsync();
        }
		public bool DeleteMovieGenres(ICollection<MovieGenre> oldMovieGenres)
        {
            _context.RemoveRange(oldMovieGenres);
			return Save();
        }
        public bool Add(MovieGenre movieGenre)
		{
			_context.Add(movieGenre);
			return Save();
		}
		public bool Delete(MovieGenre movieGenre)
		{
			_context.Remove(movieGenre);
			return Save();
		}
		public bool Save()
		{
			var saved = _context.SaveChanges();
			return saved > 0 ? true : false;
		}
		public bool Update(MovieGenre movieGenre)
		{
			_context.Update(movieGenre);
			return Save();
		}
	}
}
