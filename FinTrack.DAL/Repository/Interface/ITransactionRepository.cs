using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Repository.Interface
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetAllAsync(int userId);

        Task<Transaction> GetByIdAsync(int id);

        Task<Transaction> AddAsync(Transaction transaction);

        Task<Transaction> UpdateAsync(Transaction transaction);

        Task<bool> DeleteAsync(int id);
    }
}
