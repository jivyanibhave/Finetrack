using FinTrack.DAL.Data;
using FinTrack.DAL.Models;
using FinTrack.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Repository.Implementation
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly FinTrackDbContext _context;

        public BudgetRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetAllAsync(int userId)
        {
            return await _context.Budgets
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<Budget> GetByIdAsync(int id)
        {
            return await _context.Budgets
                .FirstOrDefaultAsync(x => x.BudgetId == id);
        }

        public async Task<Budget> AddAsync(Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();

            return budget;
        }

        public async Task<Budget> UpdateAsync(Budget budget)
        {
            _context.Budgets.Update(budget);

            await _context.SaveChangesAsync();

            return budget;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var budget =
                await _context.Budgets.FindAsync(id);

            if (budget == null)
                return false;

            _context.Budgets.Remove(budget);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
