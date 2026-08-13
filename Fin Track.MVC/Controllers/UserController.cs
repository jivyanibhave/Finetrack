using Fin_Track.MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Fin_Track.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7107/api/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var response = await _httpClient.PostAsync(
                    $"Auth/login?email={email}&password={password}",
                    null);

                if (response.IsSuccessStatusCode)
                {
                    var json =
                        await response.Content.ReadAsStringAsync();

                    var result =
                        JsonSerializer.Deserialize<LoginResponseDto>
                        (
                            json,
                            new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            }
                        );

                    if (result == null || string.IsNullOrWhiteSpace(result.Token))
                    {
                        ViewBag.Error = "Token was not returned by the API.";
                        return View();
                    }

                    HttpContext.Session.SetString(
                        "Token",
                        result.Token);

                    return RedirectToAction(
                        "Index",
                        "Home");
                }

                ViewBag.Error =
                    await response.Content.ReadAsStringAsync();

                return View();
            }
            catch (HttpRequestException ex)
            {
                ViewBag.Error =
                    $"Unable to connect to the API. {ex.Message}";

                return View();
            }
            catch (JsonException ex)
            {
                ViewBag.Error =
                    $"Invalid response received from the API. {ex.Message}";

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error =
                    $"An unexpected error occurred. {ex.Message}";

                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVMDto user)
        {
            try
            {
                var json = JsonSerializer.Serialize(user);

                var content = new StringContent(
                    json,
                    Encoding.UTF8,
                    "application/json");

                var response =
                    await _httpClient.PostAsync("Auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] =
                        "User Registered Successfully.";

                    return RedirectToAction(nameof(Login));
                }

                ViewBag.Error =
                    await response.Content.ReadAsStringAsync();

                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(user);
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Login));
        }


        //=================== INDEX ===================//

        public IActionResult Index()
        {
            return View();
        }

    }
}
