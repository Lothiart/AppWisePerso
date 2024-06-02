using Services.DTOs.ModelDTOs;
using Services.DTOs.BrandDTOs;
using Entities;


namespace Repositories.Contracts;

public interface IModelRepository
{
    Task AddAsync(ModelAddDto modelAddDto);
    Task<ModelGetDto> GetByIdAsync(int id);
    Task<List<ModelGetDto>> GetAllAsync();
    Task UpdateAsync(ModelUpdateDto modelUpdateDto);
    Task DeleteAsync(int id);
    Task<List<ModelGetDto>> GetByBrandAsync(int id);
}
