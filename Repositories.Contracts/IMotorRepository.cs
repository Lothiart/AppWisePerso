using DTOs;

namespace Repositories.Contracts;

public interface IMotorRepository
{
    Task<MotorAddDto> AddAsync(MotorAddDto motorAddDto);
    Task<List<MotorGetDto>> GetAllAsync();
    Task<MotorGetDto> GetByIdAsync(int id);
    Task<MotorUpdateDto> UpdateAsync();
    Task DeleteAsync(int id);
}