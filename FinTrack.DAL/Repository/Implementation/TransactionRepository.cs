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
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FinTrackDbContext _context;

        public TransactionRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetAllAsync(int userId)
        {
            return await _context.Transactions
                .Where(x => x.UserId == userId)
                .Include(x => x.Category)
                .ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(int id)
        {
            return await _context.Transactions
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.TransactionId == id);
        }

        public async Task<Transaction> AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<Transaction> UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var transaction =
                await _context.Transactions.FindAsync(id);

            if (transaction == null)
                return false;

            _context.Transactions.Remove(transaction);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
