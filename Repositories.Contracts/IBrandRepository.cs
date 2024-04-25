using DTOs.DTOs.BrandDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface IBrandRepository
{
    Task AddAsync(BrandAddDto brandDto);
    Task<BrandGetDto> GetById(int id);
    Task<List<BrandGetDto>> GetAllAsync();
    Task UpdateAsync(BrandUpdateDto brandUpdateDto);
    Task DeleteAsync(int id);
}