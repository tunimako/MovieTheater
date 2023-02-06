using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.ViewModels;
using MovieTheater.Models;

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
            showtimesMoviesViewModel.Cinema = await _cinemaRepository.GetCinemaByIdAsync(id);
            showtimesMoviesViewModel.Id = id;

            if (showtimesMoviesViewModel == null)
            {
                return NotFound();
            }
            else
            {
                return View(showtimesMoviesViewModel);
            }
        }
        [HttpGet]
        public async Task<IActionResult> ShowtimeCreate(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var createShowtimeViewModel = new CreateShowtimeViewModel();
            createShowtimeViewModel.Movies = await _moviesRepository.GetAllMoviesAsync();
            createShowtimeViewModel.Cinema = await _cinemaRepository.GetCinemaByIdAsync(id);

            if (createShowtimeViewModel == null)
            {
                return NotFound();
            }
            else
            {
                return View(createShowtimeViewModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> ShowtimeCreate(CreateShowtimeViewModel newShowtime)
        {
            if (!ModelState.IsValid || !SowtimeTimeValidation(newShowtime))
            {
                ModelState.AddModelError("", "Failed to create Showtime");
                newShowtime.Movies = await _moviesRepository.GetAllMoviesAsync();
                newShowtime.Cinema = await _cinemaRepository.GetCinemaByIdAsync(newShowtime.Id);
                return View("ShowtimeCreate", newShowtime);
            }
            DateTime movieStart = newShowtime.Day.AddHours(newShowtime.Time.Hour)
                                                 .AddMinutes(newShowtime.Time.Minute);
            var showtime = new ShowTime(movieStart);
            showtime.Movie = await _moviesRepository.GetMovieByIdAsync(newShowtime.MovieId.ToString());
            showtime.Cinema = await _cinemaRepository.GetCinemaByIdAsync(newShowtime.Id);
            showtime.CinemaHall = showtime.Cinema.CinemaHalls.FirstOrDefault(x => x.Id.ToString() == newShowtime.CinemaHallId);
            _showtimeRepository.Add(showtime);

            return RedirectToAction("Showtimes", new { id = newShowtime.Id });
        }
        private bool SowtimeTimeValidation(CreateShowtimeViewModel newShowtime)
        {
            if (newShowtime.Day.Ticks < DateTime.Today.AddDays(1).Ticks)
            {
                TempData["Error"] = "Showtime can't be created for past or today.";
                return false;
            }
            else if (newShowtime.Time.Ticks == 0)
            {
                return false;
            }
            newShowtime.Movie = _moviesRepository.GetMovieById(newShowtime.MovieId.ToString());
            newShowtime.Cinema = _cinemaRepository.GetCinemaById(newShowtime.Id);
            DateTime movieStart = newShowtime.Day.AddHours(newShowtime.Time.Hour)
                                                 .AddMinutes(newShowtime.Time.Minute);
            DateTime movieEnd = movieStart.Add(newShowtime.Movie.Duration);  
            long movieEndTick = movieEnd.TimeOfDay.Ticks;

            if (movieEnd.Day > movieStart.Day)
            {
                movieEndTick += TimeSpan.TicksPerDay;
            }
            TimeSpan cinemaOpenTime = TimeSpan.FromHours(newShowtime.Cinema.OpenTimeHour) +
                                      TimeSpan.FromMinutes(newShowtime.Cinema.OpenTimeMinutes);
            TimeSpan cinemaCloseTime = TimeSpan.FromHours(newShowtime.Cinema.CloseTimeHour) +
                                       TimeSpan.FromMinutes(newShowtime.Cinema.CloseTimeMinutes);
            long cinemaCloseTimeTick = cinemaCloseTime.Ticks;

            if (cinemaCloseTime.Ticks < cinemaOpenTime.Ticks)
            {
                cinemaCloseTimeTick += TimeSpan.TicksPerDay;
            }

            if ((cinemaOpenTime.Ticks > movieStart.TimeOfDay.Ticks) ||
                (cinemaCloseTimeTick < movieEndTick))
            {
                TempData["Error"] = "Showtime must be created during movie theater working hours.";
                return false;
            }
            else if(!ShowtimeCrossOverCheck(newShowtime, movieStart, movieEndTick))
            {
                TempData["Error"] = "This time is reserved for another showtime.";
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool ShowtimeCrossOverCheck(CreateShowtimeViewModel newShowtime,DateTime movieStart,long movieEndTick)
        {
            var cinemaHall = newShowtime.Cinema.CinemaHalls.FirstOrDefault(x => x.Id.ToString() == newShowtime.CinemaHallId);
            foreach (ShowTime showtime in cinemaHall.ShowTimes)
            {
                if (showtime.Start.DayOfYear == newShowtime.Day.DayOfYear)
                {
                    DateTime showtimeEnd = showtime.Start.Add(showtime.Movie.Duration);
                    long showtimeEndTick = showtimeEnd.TimeOfDay.Ticks;

                    if (showtimeEnd.Day > movieStart.Day)
                    {
                        showtimeEndTick += TimeSpan.TicksPerDay;
                    }

                    if (showtime.Start.TimeOfDay.Ticks < movieStart.TimeOfDay.Ticks
                        && showtimeEndTick > movieStart.TimeOfDay.Ticks)
                    {
                        return false;
                    }
                    else if (showtime.Start.TimeOfDay.Ticks < movieEndTick
                            && showtimeEndTick > movieEndTick)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                var showtime = await _showtimeRepository.GetShowtimeByIdAsync(id);
                _showtimeRepository.Delete(showtime);
                return RedirectToAction("Showtimes", new { id = showtime.Cinema.Id });
            }
            return RedirectToAction("Index");
        }
        public IActionResult Clients(string? id)
        {
            if(id != null)
            {
                var cinema = _cinemaRepository.GetCinemaById(id);
                return View("Clients", cinema);
            }
            return View("Cinema");
        }
    }
}
