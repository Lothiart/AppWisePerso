using Services.DTOs.BrandDTOs;
using Entities;

namespace Repositories.Contracts;
public interface IBrandRepository
{
    Task<BrandAddDto> AddAsync(BrandAddDto brandDto);
    Task<BrandGetDto> GetByIdAsync(int id);
    Task<List<BrandGetDto>> GetAllAsync();
    Task<Brand> UpdateAsync(BrandUpdateDto brandUpdateDto);
    Task<bool> DeleteAsync(int id);
}