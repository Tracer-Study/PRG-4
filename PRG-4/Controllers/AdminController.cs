using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
