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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FinTrackDbContext _context;

        public CategoryRepository(FinTrackDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.CategoryId == id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);

            await _context.SaveChangesAsync();

            return category;
        }
    }
}
