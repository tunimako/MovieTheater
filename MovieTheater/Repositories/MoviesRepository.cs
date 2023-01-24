using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Models.Enums;

namespace MovieTheater.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MovieTheaterDbContext _context;

        public MoviesRepository(MovieTheaterDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.Include(x => x.MovieGenres).ToListAsync();
        }
        
        
        public async Task<IEnumerable<Movie>> GetMovieByIdAsync(string id)
        {
            return await _context.Movies.FromSqlInterpolated($"exec getMovieById @Id={id}").ToListAsync();
                //Movies.Include(x => x.MovieGenres).FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }
        public bool Add(Movie movie)
        {
            _context.Add(movie);
            return Save();
        }
        public bool Delete(Movie movie)
        {
            _context.Remove(movie);
            return Save();
        }
        public bool Update(Movie movie)
        {
            _context.Update(movie);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        Task<Movie> IMoviesRepository.GetMovieAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
