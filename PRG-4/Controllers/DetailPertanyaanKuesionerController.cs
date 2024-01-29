using Microsoft.AspNetCore.Mvc;

namespace PRG_4.Controllers
{
    public class DetailPertanyaanKuesionerController : Controller
    {
        public IActionResult Index(string id_pku, int jenis)
        {
            var name = HttpContext.Session.GetString("Name");

            ViewData["LoginName"] = name;

            ViewData["IdPku"] = id_pku;
            ViewData["Jenis"] = jenis;

            return View();
        }
    }
}
