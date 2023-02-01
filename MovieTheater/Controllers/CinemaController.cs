using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.ViewModels;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using System.Dynamic;

namespace MovieTheater.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaRepository _cinemaRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        public CinemaController(ICinemaRepository cinemaRepository, 
                                IMoviesRepository moviesRepository, 
                                IShowtimeRepository showtimeRepository)
        {
            _cinemaRepository = cinemaRepository;
            _moviesRepository = moviesRepository;
            _showtimeRepository = showtimeRepository;
        }

        public async Task<IActionResult> Index()
        {
            var cinemas = await _cinemaRepository.GetAll();
            return View(cinemas);
        }
        public async Task<IActionResult> Showtimes(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var showtimesMoviesViewModel = new ShowtimesMoviesViewModel();
            showtimesMoviesViewModel.Showtimes = await _showtimeRepository.GetAllByCinemaIdAsync(id);
            showtimesMoviesViewModel.Movies = await _moviesRepository.GetAllMoviesAsync();

            if (showtimesMoviesViewModel == null)
            {
                return NotFound();
            }
            else
            {
                return View(showtimesMoviesViewModel);
            }
        }
        public async Task<IActionResult> ShowtimeCreate(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var createShowtimeViewModel = new CreateShowtimeViewModel();
            createShowtimeViewModel.Showtime = await _showtimeRepository.GetShowtimeByCinemaIdAsync(id);
            createShowtimeViewModel.Movies = await _moviesRepository.GetAllMoviesAsync();

            if (createShowtimeViewModel == null)
            {
                return NotFound();
            }
            else
            {
                return View(createShowtimeViewModel);
            }
        }
    }
}
