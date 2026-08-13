using FinTrack.BLL.DTO;
using FinTrack.BLL.Service.Interface;
using FinTrack.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fin_Track.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(
            ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result =
                await _categoryService.GetAllAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            CategoryRequestDTO category)
        {
            var result =
                await _categoryService.AddAsync(category);

            return Ok(result);
        }
    }
}
