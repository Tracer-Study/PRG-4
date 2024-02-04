using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class DetailPertanyaanKuesionerController : Controller
    {
        public IActionResult Index(string id_pku, int jenis)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index", "Login");
            }
            var name = HttpContext.Session.GetString("Name");
            var token = HttpContext.Session.GetString("JwtToken");

            ViewData["LoginName"] = name;
            ViewData["JwtToken"] = token;


            ViewData["IdPku"] = id_pku;
            ViewData["Jenis"] = jenis;

            return View();
        }
    }
}
