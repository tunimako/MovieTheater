using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesController(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _moviesRepository.GetAllMoviesAsync();
            
            return View(movies);
        }
        //public async Task<IActionResult> Detail(string? id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return NotFound();
        //    }

        //    var movie = await _moviesRepository.GetMovieByIdAsync(id);
        //    if(movie == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(movie);
        //}
        //[HttpGet("GetMovieById")]
        //public async Task<IEnumerable<Movie>> GetMovie(string id)
        //{
        //    return await _moviesRepository.GetMovieByIdAsync(id);
        //}
    }
}
