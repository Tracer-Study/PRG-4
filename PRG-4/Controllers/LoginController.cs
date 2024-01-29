using Microsoft.AspNetCore.Mvc;
using PRG_4.Models;
using System.Text;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using PRG_4.Model;

namespace PRG_4.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                var jsonResponse = await GetJwtTokenFromWebApi(loginModel);

                if (jsonResponse != null)
                {
                    var tokenResponse = JsonConvert.DeserializeObject<ResponseModel>(jsonResponse);

                    if (tokenResponse.status == 210)
                    {
                        return Json(new { success = false, message = "Nama Pengguna atau Kata Sandi salah." });
                    }
                    else if (tokenResponse.status == 220)
                    {
                        return Json(new { success = false, message = "Terjadi Kesalahan saat Login." });
                    }
                    else
                    {
                        var token = tokenResponse.data;

                        var tokenInfo = getStatusDecodeToken(token);
                        

                        var role = tokenInfo["role"];
                        var status = tokenInfo["status"];
                        var nama = tokenInfo["name"];

                        HttpContext.Session.SetString("JwtToken", token);
                        HttpContext.Session.SetString("Name", nama);
                        HttpContext.Session.SetString("Role", role);

                        if (role == "Admin")
                        {
                            return Json(new { success = true, message = "Berhasil Login sebagai Admin.", role = role});
                        }
                        else
                        {
                            if (status == "Belum Diverifikasi")
                            {
                                return Json(new { success = false, message = "Akun Alumni belum diverifikasi." });
                            }
                            else if (status == "Ditolak")
                            {
                                return Json(new { success = false, message = "Akun Anda telah ditolak, tidak bisa login." });
                            }
                            else
                            {
                                return Json(new { success = true, message = "Berhasil Login sebagai Alumni.", role = role });
                            }
                        }
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Terjadi kesalahan saat Login" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception: {ex.Message}");

                // Return a generic error message
                return Json(new { success = false, message = "Terjadi kesalahan saat Login" });
            }
        }

        private async Task<string> GetJwtTokenFromWebApi(LoginModel loginModel)
        {
            var apiBaseUrl = "https://localhost:44384/";
            var endpoint = "https://localhost:44384/api/token/submit";

            using var httpClient = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                return token;
            }

            return null;
        }
        public Dictionary<string, string> getStatusDecodeToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            // Mendapatkan claim-claim dari token
            var claims = token.Claims;

            // Membuat dictionary untuk menyimpan nilai claim dengan key yang sesuai
            var claimDictionary = new Dictionary<string, string>();

            // Menambahkan nilai-nilai claim ke dalam dictionary
            claimDictionary.Add("role", claims.FirstOrDefault(c => c.Type == "role")?.Value);
            claimDictionary.Add("status", claims.FirstOrDefault(c => c.Type == "status")?.Value);
            claimDictionary.Add("username", claims.FirstOrDefault(c => c.Type == "username")?.Value);
            claimDictionary.Add("name", claims.FirstOrDefault(c => c.Type == "nama")?.Value);

            // Anda juga bisa menambahkan nilai claim lainnya

            return claimDictionary;
        }
    }
}
