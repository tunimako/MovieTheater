using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Data.Enums;
using MovieTheater.EditViewModels;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using System.Xml.Linq;

namespace MovieTheater.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesRepository _moviesRepository;
        private readonly IMovieGenreRepository _movieGenreRepository;

        public MoviesController(IMoviesRepository moviesRepository,IMovieGenreRepository movieGenreRepository)
        {
            _moviesRepository = moviesRepository;
            _movieGenreRepository = movieGenreRepository;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _moviesRepository.GetAllMoviesAsync();
            
            return View(movies);
        }
        public async Task<IActionResult> Detail(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var movie = await _moviesRepository.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return View(movie);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var movie = await _moviesRepository.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }
            var originalMovieGenres = new List<Genre>();

            foreach (var originalGenre in movie.MovieGenres)
            {
                originalMovieGenres.Add(originalGenre.Genre);
            }
            var checkBoxOptions = new List<EditMovieGenreViewModel>();

            foreach(Genre genre in Enum.GetValues(typeof(Genre)))
            {
                if (originalMovieGenres.Contains(genre))
                {
                    var checBoxOption = new EditMovieGenreViewModel()
                    {
                        GenreName = genre.ToString(),
                        IsChecked = true
                    };
                    checkBoxOptions.Add(checBoxOption);
                }
                else
                {
                    var checBoxOption = new EditMovieGenreViewModel()
                    {
                        GenreName = genre.ToString(),
                        IsChecked = false
                    };
                    checkBoxOptions.Add(checBoxOption);
                }
            }
            var movieVM = new EditMovieViewModel
            {
                Id = movie.Id,
                Name = movie.Name,
                MovieGenres = movie.MovieGenres,
                Description = movie.Description,
                Rating = movie.Rating,
                AgeRating = movie.AgeRating,
                Duration = movie.Duration,
                MovieGenresCheckBox = checkBoxOptions
            };

            return View(movieVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditMovieViewModel passedMovie)
        {         
            if (!ModelState.IsValid && passedMovie.MovieGenres != null)
            {
                ModelState.AddModelError("", "Failed to edit Movie");
                return View("Edit", passedMovie);
            }

            var movie = await _moviesRepository.GetMovieByIdAsync(id);

            movie.Name = passedMovie.Name;
            movie.Description = passedMovie.Description;
            movie.Rating = passedMovie.Rating;
            movie.AgeRating = passedMovie.AgeRating;
            movie.Duration = passedMovie.Duration;

            if (movie.MovieGenres != null)
            {
                _movieGenreRepository.DeleteMovieGenres(movie.MovieGenres);
            }

            var updatedMovieGernes = new List<MovieGenre>();
            foreach (var genre in passedMovie.CheckedMovieGenres)
            {
                MovieGenre movieGenre = new MovieGenre(Enum.TryParse(genre, out Genre genreValue) ?
                                                       genreValue : throw new Exception("Could not parse the movie genre"));
                movieGenre.MovieId = movie.Id;
                movieGenre.Movie = movie;
                _movieGenreRepository.Add(movieGenre);
                updatedMovieGernes.Add(movieGenre);
            }
            movie.MovieGenres = updatedMovieGernes;
            
            _moviesRepository.UpdateMovie(movie);
            return RedirectToAction("Index");
        }
    }
}
