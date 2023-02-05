using MovieTheater.Models;
using System.Threading.Tasks;

namespace MovieTheater.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<IEnumerable<Cinema>> GetAll();
        public Cinema GetCinemaById(string? id);
        public Task<Cinema> GetCinemaByIdAsync(string? id);
    }
}
