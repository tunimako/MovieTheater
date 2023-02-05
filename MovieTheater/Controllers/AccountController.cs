using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
using MovieTheater.Repositories;
using MovieTheater.ViewModels;

namespace MovieTheater.Controllers
{
	public class AccountController : Controller
	{
		private readonly IClientRepository _clientRepository;
        private readonly IShowtimeRepository _showtimeRepository;
        private readonly IMoviesRepository _moviesRepository;
        private readonly ICinemaRepository _cinemaRepository;   
        private readonly IClientShowtimeRepository _clientShowtimeRepository;

		public AccountController(IClientRepository clientRepository,
                                 IShowtimeRepository showtimeRepository,
                                 IMoviesRepository moviesRepository,
                                 ICinemaRepository cinemaRepository,
                                 IClientShowtimeRepository clientShowtimeRepository)
		{
			_clientRepository = clientRepository;
            _cinemaRepository = cinemaRepository;
            _moviesRepository = moviesRepository;
            _showtimeRepository = showtimeRepository;
            _clientShowtimeRepository = clientShowtimeRepository;
        }
		[HttpGet]
		public IActionResult Login()
		{
			LoginViewModel loginViewModel = new LoginViewModel();
			return View(loginViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            ClientViewModel client = new ClientViewModel();
            client.Client = await _clientRepository.GetClientByCredentialsAsync(loginViewModel.Username,
                                                                                loginViewModel.Password);
            client.Cinemas = await _cinemaRepository.GetAll();
            if (client.Client == null)
            {
                TempData["Error"] = "Wrong credentials. Please try again!";
                return View(loginViewModel);
            }
            return View("Cinema", client);
        }
        public async Task<IActionResult> Showtimes(ClientViewModel client)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to pass to cinema showtimes");
                client.Client = await _clientRepository.GetClientByIdAsync(client.ClientId);
                client.Cinemas = await _cinemaRepository.GetAll();
                return View("Cinema", client);
            }
            var clientShowtimesViewModel = new ClientShowtimesViewModel()
            {
                Showtimes = await _showtimeRepository.GetAllByCinemaIdAsync(client.CinemaId),
                Movies = await _moviesRepository.GetAllMoviesAsync(),
                Cinema = await _cinemaRepository.GetCinemaByIdAsync(client.CinemaId),
                ClientId = client.ClientId
            };

            return View(clientShowtimesViewModel);
        }
        public async Task<IActionResult> Reserve(ClientShowtimesViewModel clientShowtimesViewModel)
        {
            Client client = await _clientRepository.GetClientByIdAsync(clientShowtimesViewModel.ClientId);

            ClientShowTime clientShowTime = new ClientShowTime()
            {
                Client = client,
                ShowTime = await _showtimeRepository.GetShowtimeByIdAsync(clientShowtimesViewModel.ShowtimeId)
            };

            ClientViewModel clientViewModel = new ClientViewModel()
            {
                Client = await _clientRepository.GetClientByIdAsync(clientShowtimesViewModel.ClientId),
                Cinemas = await _cinemaRepository.GetAll(),
                ClientId = clientShowtimesViewModel.ClientId,
                CinemaId = clientShowTime.ShowTime.CinemaId.ToString()
            };
            clientShowtimesViewModel.ClientViewModel = clientViewModel;
            clientShowtimesViewModel.Showtimes = await _showtimeRepository.GetAllByCinemaIdAsync(clientViewModel.CinemaId);
            clientShowtimesViewModel.Cinema = await _cinemaRepository.GetCinemaByIdAsync(clientViewModel.CinemaId);

            if (!ModelState.IsValid)
            {
                return View(clientShowtimesViewModel);
            }

            if (client.ClientShowTimes.Where(x => x.ShowTimeId.ToString() == clientShowtimesViewModel.ShowtimeId)
                                      .ToList().Count > 0)
            {
                TempData["Error"] = "Client has already bought a ticket to this movie.";
                return View("Showtimes", clientShowtimesViewModel);
            }
            if (clientShowTime != null )
            {
                await _clientShowtimeRepository.Add(clientShowTime);
                TempData["Success"] = "Ticket was reserved.";
                return View("Showtimes", clientShowtimesViewModel);
            }
            return View("Showtimes", clientShowtimesViewModel);
        }
    }
}
