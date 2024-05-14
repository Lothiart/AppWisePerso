using Services.DTOs.CategoryDTOs;

namespace Repositories.Contracts;
public interface ICategoryRepository
{
    Task<CategoryAddDto> AddAsync(CategoryAddDto categoryAddDto);
    Task<CategoryGetDto> GetByIdAsync(int id);
    Task<List<CategoryGetDto>> GetAllAsync();
    Task<bool> UpdateAsync(CategoryUpdateDto categoryDto);
    Task<bool> DeleteAsync(int id);
}