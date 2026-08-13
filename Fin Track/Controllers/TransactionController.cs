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
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(
            ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var transactions = await _transactionService.GetAllAsync(userId);

            var response = transactions.Select(transaction => new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Description = transaction.Description,
                TransactionDate = transaction.TransactionDate,
                Type = transaction.Type,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category.CategoryName
            }).ToList();

            return Ok(response);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var transaction =
                await _transactionService.GetByIdAsync(id);

            var response = new TransactionResponseDto
            {
                TransactionId = transaction.TransactionId,
                Amount = transaction.Amount,
                Description = transaction.Description,
                TransactionDate = transaction.TransactionDate,
                Type = transaction.Type,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category.CategoryName
            };
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(TransactionRequestDto transaction, int userid)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result =
                await _transactionService.AddAsync(transaction, userId);

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(
            TransactionEditDto transaction)
        {
            var result =
                await _transactionService.UpdateAsync(transaction);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =
                await _transactionService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
