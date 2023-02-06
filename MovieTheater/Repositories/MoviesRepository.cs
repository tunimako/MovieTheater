using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Data.Enums;
using System.Xml;

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
            return await _context.Movies.Include(x => x.MovieGenres)
                                        .Include(s=>s.ShowTimes)
                                        .ThenInclude(c=>c.Cinema).ToListAsync();
        }
        public async Task<Movie> GetMovieByIdAsync(string? id)
        {
            return await _context.Movies.Include(x => x.MovieGenres)
                                        .Include(s=>s.ShowTimes)
                                        .ThenInclude(ch=>ch.CinemaHall)
                                        .ThenInclude(c=>c.Cinema)
                                        .Include(s=>s.ShowTimes)
                                        .ThenInclude(ch=>ch.ClientShowTimes)
                                        .FirstOrDefaultAsync(x => x.Id.ToString() == id);
        }
        public Movie GetMovieById(string? id)
        {
            return _context.Movies.Include(x => x.MovieGenres)
                                        .Include(s=>s.ShowTimes)
                                        .ThenInclude(ch=>ch.CinemaHall)
                                        .ThenInclude(c=>c.Cinema)
                                        .FirstOrDefault(x => x.Id.ToString() == id);
        }
        public async Task<Movie> GetMovieByIdAsyncAsNoTracking(string? id)
        {
            return await _context.Movies.Include(x => x.MovieGenres)
                            .Include(s => s.ShowTimes)
                            .ThenInclude(ch => ch.CinemaHall)
                            .ThenInclude(c => c.Cinema)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id.ToString() == id);
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
        public bool UpdateMovie(Movie movie)
        {
            _context.Movies.Update(movie);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
