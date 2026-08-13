using FinTrack.BLL.DTO;
using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Interface
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetAllAsync(int userId);

        Task<Transaction> GetByIdAsync(int id);

        Task<TransactionResponseDto> AddAsync(TransactionRequestDto transaction, int userId);

        Task<TransactionResponseDto> UpdateAsync(TransactionEditDto transaction);

        Task<bool> DeleteAsync(int id);
    }
}
