using Microsoft.AspNetCore.Mvc;
using MovieTheater.Interfaces;
using MovieTheater.Models;
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
			var loginViewModel = new LoginViewModel();
			return View(loginViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            var client = new ClientViewModel();
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
                Client = await _clientRepository.GetClientByIdAsync(client.ClientId),   
                ClientId = client.ClientId
            };

            return View(clientShowtimesViewModel);
        }
        public async Task<IActionResult> Reserve(ClientShowtimesViewModel clientShowtimesViewModel)
        {
            var clientShowTime = new ClientShowTime()
            {
                Client = await _clientRepository.GetClientByIdAsync(clientShowtimesViewModel.ClientId),
                ShowTime = await _showtimeRepository.GetShowtimeByIdAsync(clientShowtimesViewModel.ShowtimeId)
            };

            var clientViewModel = new ClientViewModel()
            {
                Client = await _clientRepository.GetClientByIdAsync(clientShowtimesViewModel.ClientId),
                Cinemas = await _cinemaRepository.GetAll(),
                ClientId = clientShowtimesViewModel.ClientId,
                CinemaId = clientShowTime.ShowTime.CinemaId.ToString()
            };
            clientShowtimesViewModel.ClientViewModel = clientViewModel;
            clientShowtimesViewModel.Showtimes = await _showtimeRepository.GetAllByCinemaIdAsync(clientViewModel.CinemaId);
            clientShowtimesViewModel.Cinema = await _cinemaRepository.GetCinemaByIdAsync(clientViewModel.CinemaId);
            clientShowtimesViewModel.Client = await _clientRepository.GetClientByIdAsync(clientViewModel.ClientId);   

            if (!ModelState.IsValid)
            {
                return View("Showtimes", clientShowtimesViewModel);
            }

            int freeSeats = clientShowTime.ShowTime.CinemaHall.AvailableSeats
                            - clientShowTime.ShowTime.ClientShowTimes.Count;

            if (freeSeats <= 0)
            {
                TempData["Error"] = "Showtime is full.";
                return View("Showtimes", clientShowtimesViewModel);
            }

            if (clientShowTime.Client.ClientShowTimes.Where(x => x.ShowTimeId.ToString() == clientShowtimesViewModel.ShowtimeId)
                                                     .ToList().Count > 0)
            {
                TempData["Error"] = "Client has already bought a ticket to this movie.";
                return View("Showtimes", clientShowtimesViewModel);
            }

            if (clientShowTime != null)
            {
                await _clientShowtimeRepository.Add(clientShowTime);
                TempData["Success"] = "Ticket was reserved.";
                return View("Showtimes", clientShowtimesViewModel);
            }

            return View("Showtimes", clientShowtimesViewModel);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(NewClientViewModel newClient)
        {
            if (!ModelState.IsValid)
            { 
                return View("Register");
            }

            Client client = new Client
            {
                FirstName = newClient.FirstName,
                LastName = newClient.LastName,
                DateOfBirth = newClient.DateOfBirth,
                EmailAddress = newClient.EmailAddress,
                PhoneNumber = newClient.PhoneNumber,
                Username = newClient.Username,
                Password = newClient.Password
            };
            
            if (client != null)
            {
                _clientRepository.Add(client);
            }

            return View("Login");
        }
        public async Task<IActionResult> Profile(string? id)
        {
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            var showtimes = await _showtimeRepository.GetAllShowtimesAsync();
            var clientShowtimes = await _clientShowtimeRepository.GetAllByClientIdAsync(id);
            List<ShowTime> listOfShowtimes = new List<ShowTime>();

            foreach (var clientShowtime in clientShowtimes)
            {
                foreach(var showtime in showtimes)
                {
                    if(showtime== clientShowtime.ShowTime)
                    {
                        listOfShowtimes.Add(showtime);
                    }
                }
            }

            var clientShowtimesViewModel = new ClientShowtimesViewModel()
            {
                Showtimes = listOfShowtimes,
                Client = await _clientRepository.GetClientByIdAsync(id)   
            };
            
            if(clientShowtimesViewModel == null)
            {
                return RedirectToAction("Login");
            }

            return View(clientShowtimesViewModel);
        }
    }
}
