using StockHome.API.DTOs;
using StockHome.API.Models;

namespace StockHome.API.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO.Response>> GetAllAsync();
        Task<CategoryDTO.Response> GetByIdAsync(int id);
        Task<CategoryDTO.Response> CreateAsync(CategoryDTO.Create category);
        Task<CategoryDTO.Response> UpdateAsync(int id, CategoryDTO.Update category);
        Task<bool> DeleteAsync(int id);
    }
}
