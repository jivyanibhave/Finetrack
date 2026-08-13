using Fin_Track.MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Fin_Track.MVC.Controllers
{
    public class BudgetController : Controller
    {
        private readonly HttpClient _httpClient;

        public BudgetController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress =
                new Uri("https://localhost:7107/api/");
        }

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

            var response = await _httpClient.GetAsync("Budget");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var budgets =
                    JsonSerializer.Deserialize<List<BudgetVMResponseDTO>>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(budgets);
            }

            ViewBag.Error = await response.Content.ReadAsStringAsync();

            return View(new List<BudgetVMResponseDTO>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var response =
                await _httpClient.GetAsync($"Budget/details/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json =
                    await response.Content.ReadAsStringAsync();

                var budget =
                    JsonSerializer.Deserialize<BudgetVMResponseDTO>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(budget);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(BudgetVMRequestDTO budget)
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

            var json = JsonSerializer.Serialize(budget);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PostAsync("Budget", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(budget);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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

            var response =
                await _httpClient.GetAsync($"Budget/details/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json =
                    await response.Content.ReadAsStringAsync();

                var budget =
                    JsonSerializer.Deserialize<BudgetVMResponseDTO>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(budget);
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Edit(BudgetVMUpdateRequestDTO budget)
        {
            var json = JsonSerializer.Serialize(budget);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PutAsync("Budget", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(budget);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"Budget/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
