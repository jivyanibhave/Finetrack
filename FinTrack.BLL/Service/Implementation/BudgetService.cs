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
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetService(
            IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public async Task<IEnumerable<Budget>> GetAllAsync(int userId)
        {
            if (userId <= 0)
                throw new Exception("Invalid User.");

            return await _budgetRepository.GetAllAsync(userId);
        }

        public async Task<Budget> GetByIdAsync(int id)
        {
            var budget =
                await _budgetRepository.GetByIdAsync(id);

            if (budget == null)
                throw new Exception("Budget not found.");

            return budget;
        }

        public async Task<BudgetResponseDTO> AddAsync(BudgetRequestDTO budget, int userid)
        {
            if (budget == null)
                throw new Exception("Budget data required.");

            if (budget.LimitAmount <= 0)
                throw new Exception("Budget amount must be greater than zero.");

            if (budget.EndDate <= budget.StartDate)
                throw new Exception("End Date must be greater than Start Date.");

            Budget budgetEntity = new Budget
            {
                LimitAmount = budget.LimitAmount,
                SpentAmount = 0,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
                UserId = userid
            };

            var result = await _budgetRepository.AddAsync(budgetEntity);

            return new BudgetResponseDTO
            {
                BudgetId = result.BudgetId,
                LimitAmount = result.LimitAmount,
                SpentAmount = result.SpentAmount,
                RemainingAmount = result.LimitAmount - result.SpentAmount,
                StartDate = result.StartDate,
                EndDate = result.EndDate
            };
        }

        public async Task<BudgetResponseDTO> UpdateAsync(BudgetUpdateRequestDTO dto)
        {
            var budget = await _budgetRepository.GetByIdAsync(dto.BudgetId);

            if (budget == null)
                throw new Exception("Budget not found.");

            budget.LimitAmount = dto.LimitAmount;
            budget.StartDate = dto.StartDate;
            budget.EndDate = dto.EndDate;

            var updated = await _budgetRepository.UpdateAsync(budget);

            return new BudgetResponseDTO
            {
                BudgetId = updated.BudgetId,
                LimitAmount = updated.LimitAmount,
                SpentAmount = updated.SpentAmount,
                RemainingAmount = updated.LimitAmount - updated.SpentAmount,
                StartDate = updated.StartDate,
                EndDate = updated.EndDate
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing =
                await _budgetRepository.GetByIdAsync(id);

            if (existing == null)
                throw new Exception("Budget not found.");

            return await _budgetRepository.DeleteAsync(id);
        }
    }
}

