using System.Linq;
using System.Threading.Tasks;
using AutomaticSharp.Auth;
using AutomaticSharp.Demo.ViewModels;
using AutomaticSharp.Requests;
using AutoMapper;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;

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
                var client = new Client(User.FindFirst(c => c.Type == "access_token").Value);

                var vehicles = (await client.GetVehiclesAsync()).Results;

                model.Vehicles = vehicles.ToDictionary(key => key.Id, vehicle => vehicle.DisplayName ?? vehicle.Id);
            }

            return View(model);
        }

        [Authorize]
        [Route("Home/Vehicle/{id}")]
        public async Task<IActionResult> Vehicle(string id)
        {
            var client = new Client(User.FindFirst(c => c.Type == "access_token").Value);
            var getVehicleTask = client.GetVehicleAsync(id);
            var getTripsTask = client.GetTripsAsync(new TripsRequest { VehicleId = id });

            var vehicle = await getVehicleTask;

            var model = Mapper.Map<VehicleViewModel>(vehicle);

            var trips = await getTripsTask;

            model.Trips = trips.Results.Select(Mapper.Map<TripViewModel>).ToList();

            return View(model);
        }

        public IActionResult Error(string failureMessage = null)
        {
            return View(failureMessage ?? string.Empty);
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
            await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
