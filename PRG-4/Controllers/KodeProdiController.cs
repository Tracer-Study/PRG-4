using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class KodeProdiController : Controller
    {
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
    }
}
