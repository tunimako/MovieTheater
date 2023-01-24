using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface IMoviesRepository
    {
        public Task<IEnumerable<Movie>> GetAllMoviesAsync();
        public Task<Movie> GetMovieAsync(string id);
        public Task<IEnumerable<Movie>> GetMovieByIdAsync(string id);
        bool Add(Movie movie);
        bool Update(Movie movie);
        bool Delete(Movie movie);
        bool Save();
    }
}