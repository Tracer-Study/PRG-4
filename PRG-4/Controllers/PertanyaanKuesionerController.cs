using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class PertanyaanKuesionerController : Controller
    {
        public IActionResult Index()
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;
            return View();
        }
    }
}
