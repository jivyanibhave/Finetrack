using Fin_Track.MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Fin_Track.MVC.Controllers
{
    public class DashboardController : Controller
    {

        private readonly HttpClient _httpClient;

        public DashboardController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress =
                new Uri("https://localhost:7107/api/");
        }

        //public async Task<IActionResult> Index(int userId)
        //{
        //    var response =
        //        await _httpClient.GetAsync($"Dashboard/{userId}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var json =
        //            await response.Content.ReadAsStringAsync();

        //        var dashboard =
        //            JsonSerializer.Deserialize<DashboardVMDto>
        //            (
        //                json,
        //                new JsonSerializerOptions
        //                {
        //                    PropertyNameCaseInsensitive = true
        //                }
        //            );

        //        return View(dashboard);
        //    }

        //    return View();
        //}

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("Token");

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "User");
            }

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    token);

            var response = await _httpClient.GetAsync("Dashboard");

            if (!response.IsSuccessStatusCode)
            {
                return View(new DashboardVMDto());
            }

            var json = await response.Content.ReadAsStringAsync();

            var dashboard =
                JsonSerializer.Deserialize<DashboardVMDto>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return View(dashboard ?? new DashboardVMDto());
        }

    }
}
