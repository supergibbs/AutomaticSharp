using System.Threading.Tasks;
using AutomaticSharp.Auth;
using AutomaticSharp.Demo.ViewModels;
using AutomaticSharp.Requests;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;

namespace AutomaticSharp.Demo.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            if (User.Identity.IsAuthenticated)
            {
                var client = new Client(User.FindFirst(c=>c.Type == "access_token").Value);
                model.Vehicles = (await client.GetVehiclesAsync()).Results;
            }

            return View(model);
        }

        public IActionResult Docs()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
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
