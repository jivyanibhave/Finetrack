using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.DAL.Repository.Interface
{
    public interface IBudgetRepository
    {
        Task<IEnumerable<Budget>> GetAllAsync(int userId);

        Task<Budget> GetByIdAsync(int id);

        Task<Budget> AddAsync(Budget budget);

        Task<Budget> UpdateAsync(Budget budget);

        Task<bool> DeleteAsync(int id);
    }
}
