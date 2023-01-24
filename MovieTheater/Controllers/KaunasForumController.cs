using Microsoft.AspNetCore.Mvc;
using MovieTheater.Data;
using MovieTheater.Models;

namespace MovieTheater.Controllers
{
    public class KaunasForumController : Controller
    {
        private readonly MovieTheaterDbContext _context;

        public KaunasForumController(MovieTheaterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Cinema kaunasForum = _context.Cinemas.FirstOrDefault(x => x.Name == "KaunasForum");
            return View(kaunasForum);
        }
    }
}
