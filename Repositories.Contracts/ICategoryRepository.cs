using DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface ICategoryRepository
{
    Task AddAsync(CategoryAddDto categoryAddDto);
    Task<CategoryGetDto> GetByIdAsync(int id);
    Task<List<CategoryGetDto>> GetAllAsync();
    Task UpdateAsync(int id);
    Task DeleteAsync(int id);
}