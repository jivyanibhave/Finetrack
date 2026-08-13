using FinTrack.BLL.DTO;
using FinTrack.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Repo
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly FinTrackDbContext _context;

        public DashboardRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<DashboardDto> GetDashboardAsync(int userId)
        {
            var transactions = await _context.Transactions
                .Where(x => x.UserId == userId)
                .ToListAsync();

            var budgets = await _context.Budgets
                .Where(x => x.UserId == userId)
                .ToListAsync();

            decimal income = transactions
                .Where(x => x.Type == "Income")
                .Sum(x => x.Amount);

            decimal expense = transactions
                .Where(x => x.Type == "Expense")
                .Sum(x => x.Amount);

            decimal totalBudget = budgets
                .Sum(x => x.LimitAmount);

            return new DashboardDto
            {
                TotalIncome = income,
                TotalExpense = expense,
                Balance = income - expense,
                MonthlyBudget = totalBudget,
                BudgetUsed = expense
            };
        }
    }
}
