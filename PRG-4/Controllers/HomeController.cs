using Microsoft.AspNetCore.Mvc;
using PRG_4.Models;
using System.Diagnostics;

namespace PRG_4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;

            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}