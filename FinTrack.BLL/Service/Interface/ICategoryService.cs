using FinTrack.BLL.DTO;
using FinTrack.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinTrack.BLL.Service.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();

        Task<CategoryResponseDto> AddAsync(CategoryRequestDTO category);
    }
}
