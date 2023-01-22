using Microsoft.AspNetCore.Mvc;

namespace MovieTheater.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
