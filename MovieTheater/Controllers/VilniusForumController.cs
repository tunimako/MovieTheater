using Microsoft.AspNetCore.Mvc;
using MovieTheater.Data;
using MovieTheater.Models;

namespace MovieTheater.Controllers
{
    public class VilniusForumController : Controller
    {
        private readonly MovieTheaterDbContext _context;

        public VilniusForumController(MovieTheaterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Name == "VilniusForum");
            return View(cinema);
        }
    }
}
