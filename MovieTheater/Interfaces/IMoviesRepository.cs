using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetMovieByIdAsync(string? id);
        public Movie GetMovieById(string? id);
        public Task<Movie> GetMovieByIdAsyncAsNoTracking(string? id);
        bool Add(Movie movie);
        bool UpdateMovie(Movie movie);
        bool Delete(Movie movie);
        bool Save();
    }
}