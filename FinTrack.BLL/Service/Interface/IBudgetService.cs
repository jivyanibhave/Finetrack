using FinTrack.BLL.DTO;
using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Interface
{
    public interface IBudgetService
    {
        Task<IEnumerable<Budget>> GetAllAsync(int userId);

        Task<Budget> GetByIdAsync(int id);

        Task<BudgetResponseDTO> AddAsync(BudgetRequestDTO budget, int userid);

        Task<BudgetResponseDTO> UpdateAsync(BudgetUpdateRequestDTO budget);

        Task<bool> DeleteAsync(int id);
    }
}
