using Services.DTOs.CategoryDTOs;
using Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface ICategoryRepository
{
    Task<CategoryAddDto> AddAsync(CategoryAddDto categoryAddDto);
    Task<CategoryGetDto> GetByIdAsync(int id);
    Task<List<CategoryGetDto>> GetAllAsync();
    Task<bool> UpdateAsync(CategoryUpdateDto categoryDto);
    Task<bool> DeleteAsync(int id);
}