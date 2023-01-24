using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using MovieTheater.Data;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using System.Text.Encodings.Web;

namespace MovieTheater.Controllers
{
    public class KlaipedaForumController : Controller
    {
        private readonly MovieTheaterDbContext _context;

        public KlaipedaForumController(MovieTheaterDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(x => x.Name == "KlaipėdaForum");
            return View(cinema);
        }
    }
}
