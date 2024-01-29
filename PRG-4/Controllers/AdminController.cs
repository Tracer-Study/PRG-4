using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;

            return View();
        }
        public IActionResult DetailByProdi(int idProdi, int tahun, int status)
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;

            ViewData["Tahun"] = tahun;
            ViewData["IdProdi"] = idProdi;
            ViewData["Status"] = status;

            return View();
        }
        public IActionResult DetailByYear(int year)
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;

            ViewData["Tahun"] = year;

            return View();
        }
        public IActionResult DetailJawabanAlumni(string nim)
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;
            ViewData["Nim"] = nim;

            return View();
        }
        public IActionResult AkunBelumVerifikasi(int year)
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;
            ViewData["Tahun"] = year;

            return View();
        }
    }
}
