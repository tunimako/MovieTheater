using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieTheater.Data;
using MovieTheater.Models;

namespace MovieTheater.Controllers
{
    public class CinemaController : Controller
    {
        private readonly MovieTheaterDbContext _context;

        public CinemaController(MovieTheaterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cinema = _context.Cinemas.ToList();
            return View(cinema);
        }
        public IActionResult Kaunas()
        {
            Cinema cineam = _context.Cinemas.FirstOrDefault(x => x.Name == "KaunasForum");
            return View(cineam);
        }
        public IActionResult Detail(string name)
        {
            Cinema cineam = _context.Cinemas.FirstOrDefault(x => x.Name == name);
            return View(cineam);
        }
    }
}
