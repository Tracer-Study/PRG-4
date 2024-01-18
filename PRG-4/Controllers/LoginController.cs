using Microsoft.AspNetCore.Mvc;
using PRG_4.Models;

namespace PRG_4.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginModel loginModel)
        {
            if (loginModel.Email == "username1" && loginModel.Password == "password1")
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
    }
}
