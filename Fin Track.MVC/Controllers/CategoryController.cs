using Fin_Track.MVC.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace Fin_Track.MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;

        public CategoryController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress =
                new Uri("https://localhost:7107/api/");
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("Category");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();

                var categories =
                    JsonSerializer.Deserialize<List<CategoryVMResponseDto>>
                    (
                        json,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                return View(categories);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(
            CategoryVMRequestDto category)
        {
            var json = JsonSerializer.Serialize(category);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json");

            var response =
                await _httpClient.PostAsync("Category", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        
    }
}
