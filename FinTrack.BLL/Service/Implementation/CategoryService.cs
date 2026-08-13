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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<CategoryResponseDto> AddAsync(CategoryRequestDTO category)
        {
            if (category == null)
                throw new Exception("Category data required.");

            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new Exception("Category Name is required.");

            Category newCategory = new Category
            {
                CategoryName = category.CategoryName
            };

            var addedCategory = await _categoryRepository.AddAsync(newCategory);

            return new CategoryResponseDto
            {
                CategoryId = addedCategory.CategoryId,
                CategoryName = addedCategory.CategoryName
            };
        }
    }
}
