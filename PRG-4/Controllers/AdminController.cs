using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DetailByProdi(int idProdi, int tahun, int status)
        {
            ViewData["Tahun"] = tahun;
            ViewData["IdProdi"] = idProdi;
            ViewData["Status"] = status;

            return View();
        }
        public IActionResult DetailJawabanAlumni(int nim)
        {
            ViewData["Nim"] = nim;

            return View();
        }
    }
}
