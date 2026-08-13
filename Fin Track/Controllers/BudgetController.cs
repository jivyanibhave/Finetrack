using FinTrack.BLL.DTO;
using FinTrack.BLL.Service.Interface;
using FinTrack.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fin_Track.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(
            IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _budgetService.GetAllAsync(userId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result =
                await _budgetService.GetByIdAsync(id);

            return Ok(result);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(BudgetRequestDTO budget)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result =
                await _budgetService.AddAsync(budget, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(BudgetUpdateRequestDTO budget)
        {
            var result =
                await _budgetService.UpdateAsync(budget);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _budgetService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
