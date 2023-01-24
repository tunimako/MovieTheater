using MovieTheater.Models;

namespace MovieTheater.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<IEnumerable<Cinema>> GetAll();
        public Task<Cinema> GetByIdAsync(int id);
        
    }
}
