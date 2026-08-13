using Fin_Track.MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Fin_Track.MVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly HttpClient _httpClient;

        public TransactionController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress =
                new Uri("https://localhost:7107/api/");
        }

        public async Task<IActionResult> Index(int userId)
        {
            var result = HttpContext.Session.GetString("Token");

            var response =
                await _httpClient.GetAsync($"Transaction/{userId}");

            if (response.IsSuccessStatusCode)
            {
                var json =
                    await response.Content.ReadAsStringAsync();

                var transactions =
                    JsonSerializer.Deserialize<List<TransactionResponseDto>>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(transactions);
            }

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var response =
                await _httpClient.GetAsync($"Transaction/details/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json =
                    await response.Content.ReadAsStringAsync();

                var transaction =
                    JsonSerializer.Deserialize<TransactionResponseDto>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(transaction);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TransactionVMRequestDto transaction)
        {
            var token = HttpContext.Session.GetString("Token");
            if(string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "User");
            }

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    token);

            var json = JsonSerializer.Serialize(transaction);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PostAsync("Transaction", content);

            //if (response.IsSuccessStatusCode)
            //{
            //    int? userId = HttpContext.Session.GetInt32("UserId");

            //    return RedirectToAction(
            //        nameof(Index),
            //        new { userId = userId });
            //}

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View(transaction);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("Token");
            if(string.IsNullOrEmpty(token))
            {
                return RedirectToAction("Login", "User");
            }

            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue(
                    "Bearer",
                    token);

            var response =
                await _httpClient.GetAsync($"Transaction/details/{id}");

            if (response.IsSuccessStatusCode)
            {
                var json =
                    await response.Content.ReadAsStringAsync();

                var transaction =
                    JsonSerializer.Deserialize<TransactionResponseDto>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(transaction);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(
            TransactionEditDto transaction)
        {
            var json = JsonSerializer.Serialize(transaction);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PutAsync("Transaction", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(transaction);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response =
                await _httpClient.DeleteAsync($"Transaction/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
