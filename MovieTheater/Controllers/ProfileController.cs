using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;

namespace MovieTheater.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IClientRepository _client;

        public ProfileController(IClientRepository client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        } 
        public async Task<IActionResult> Client(string id)
        {
            var Client = await _client.GetClientByIdAsync(id);
            return View(Client);
        }
    }
}
