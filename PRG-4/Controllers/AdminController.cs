using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class AdminController : Controller
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
        public IActionResult DetailByProdi(int idProdi, int tahun, int status)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;

            ViewData["Tahun"] = tahun;
            ViewData["IdProdi"] = idProdi;
            ViewData["Status"] = status;

            return View();
        }
        public IActionResult DetailByYear(int year)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;

            ViewData["Tahun"] = year;

            return View();
        }
        public IActionResult DetailJawabanAlumni(string nim)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;
            ViewData["Nim"] = nim;

            return View();
        }
        public IActionResult AkunBelumVerifikasi(int year)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;

            ViewData["Tahun"] = year;

            return View();
        }
    }
}
