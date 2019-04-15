using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutomaticSharp.Demo.Models;
using AutomaticSharp.Requests;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutomaticSharp.Auth;
using System.Collections.Generic;

namespace AutomaticSharp.Demo.Controllers
{
    public class HomeController : Controller
    {
        private IMapper Mapper { get; }

        public HomeController(IMapper mapper)
        {
            Mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            if (User.Identity.IsAuthenticated)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                var client = new Client(accessToken);

                var vehicles = (await client.GetVehiclesAsync()).Results;

                model.Vehicles = vehicles.ToDictionary(key => key.Id, vehicle => vehicle.DisplayName ?? vehicle.Id);
            }

            return View(model);
        }

        [Authorize]
        [Route("Home/Vehicle/{id}")]
        public async Task<IActionResult> Vehicle(string id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new Client(accessToken);

            var getVehicleTask = client.GetVehicleAsync(id);
            var getTripsTask = client.GetTripsAsync(new TripsRequest { VehicleId = id });

            var vehicle = await getVehicleTask;

            var model = Mapper.Map<VehicleViewModel>(vehicle);

            var trips = await getTripsTask;

            model.Trips = trips.Results?.Select(Mapper.Map<TripViewModel>).ToList() ?? new List<TripViewModel>();

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login()
        {
            return new ChallengeResult(AutomaticDefaults.AuthenticationScheme, new AuthenticationProperties { RedirectUri = new PathString("/") });
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
