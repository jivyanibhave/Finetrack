using FinTrack.BLL.DTO;
using FinTrack.BLL.Service.Interface;
using FinTrack.DAL.Models;
using FinTrack.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TransactionService(
            ITransactionRepository transactionRepository,
            ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(int userId)
        {
            if (userId <= 0)
                throw new Exception("Invalid User.");

            return await _transactionRepository.GetAllAsync(userId);
        }

        public async Task<Transaction> GetByIdAsync(int id)
        {
            var transaction =
                await _transactionRepository.GetByIdAsync(id);

            if (transaction == null)
                throw new Exception("Transaction not found.");

            return transaction;
        }

        public async Task<TransactionResponseDto> AddAsync(TransactionRequestDto transaction, int userId)
        {
            if (transaction == null)
                throw new Exception("Transaction data required.");

            if (transaction.Type != "Income" && transaction.Type != "Expense")
            {
                throw new Exception("Transaction type must be Income or Expense.");
            }

            if (transaction.Amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            if (transaction.TransactionDate > DateTime.Now)
                throw new Exception("Future date not allowed.");

            var category =
                await _categoryRepository.GetByIdAsync(
                    transaction.CategoryId);

            if (category == null)
                throw new Exception("Category not found.");

            Transaction transaction1 = new Transaction
            {
                Amount = transaction.Amount,
                Description = transaction.Description,
                TransactionDate = transaction.TransactionDate,
                Type = transaction.Type,
                CategoryId = transaction.CategoryId,
                UserId = userId
            };

            var result = await _transactionRepository.AddAsync(transaction1);

            return new TransactionResponseDto
            {
                TransactionId = result.TransactionId,
                Amount = result.Amount,
                Description = result.Description,
                TransactionDate = result.TransactionDate,
                Type = result.Type,
                CategoryId = result.CategoryId,
                
            };
        }

        public async Task<TransactionResponseDto> UpdateAsync(TransactionEditDto transaction)
        {
            var existing = await _transactionRepository.GetByIdAsync(transaction.TransactionId);

            if (existing == null)
                throw new Exception("Transaction not found.");

            if (transaction.Amount <= 0)
                throw new Exception("Amount must be greater than zero.");

            if (transaction.TransactionDate > DateTime.Now)
                throw new Exception("Future date not allowed.");

            if (transaction.Type != "Income" && transaction.Type != "Expense")
                throw new Exception("Transaction type must be Income or Expense.");

            var category = await _categoryRepository.GetByIdAsync(transaction.CategoryId);

            if (category == null)
                throw new Exception("Category not found.");

            existing.Amount = transaction.Amount;
            existing.Description = transaction.Description;
            existing.TransactionDate = transaction.TransactionDate;
            existing.Type = transaction.Type;
            existing.CategoryId = transaction.CategoryId;

            var result = await _transactionRepository.UpdateAsync(existing);

            return new TransactionResponseDto
            {
                TransactionId = result.TransactionId,
                Amount = result.Amount,
                Description = result.Description,
                TransactionDate = result.TransactionDate,
                Type = result.Type,
                CategoryId = result.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing =
                await _transactionRepository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Transaction not found.");

            return await _transactionRepository.DeleteAsync(id);
        }
    }
}
