using DTOs.DTOs.StatusDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IStatusRepository
{
    Task<StatusAddDto> AddAsync(StatusAddDto statusAddDto);
    Task<List<StatusGetDto>> GetAllAsync();
    Task<StatusGetDto> GetByIdAsync(int id);
    Task<Status> UpdateAsync(StatusUpdateDto statusUpdateDto);
    Task<Status> DeleteAsync(int id);
}
