using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
