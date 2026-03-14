using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using StockHome.API.Data;
using StockHome.API.DTOs;
using StockHome.API.Models;
using StockHome.API.Services.Interfaces;

namespace StockHome.API.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<CategoryDTO.Response> CreateAsync(CategoryDTO.Create category)
        {
            var newCategory = new Category();
            if (category != null)
            {
                newCategory.Name = category.Name;
                newCategory.Id = _context.Categories.Count() + 1;
            }

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();

            return new CategoryDTO.Response(newCategory.Id, newCategory.Name);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryDTO.Response>> GetAllAsync()
        {
            return await _context.Categories.Select(c => new CategoryDTO.Response(c.Id, c.Name)).ToListAsync();
        }

        public async Task<CategoryDTO.Response> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null!;
            return new CategoryDTO.Response(category.Id, category.Name);
        }

        public async Task<CategoryDTO.Response> UpdateAsync(int id, CategoryDTO.Update category)
        {
            var categoryToUpdate = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryToUpdate == null) return null!;

            categoryToUpdate.Name = category.Name;

            await _context.SaveChangesAsync();
            return new CategoryDTO.Response(categoryToUpdate.Id, categoryToUpdate.Name);
        }
    }
}
