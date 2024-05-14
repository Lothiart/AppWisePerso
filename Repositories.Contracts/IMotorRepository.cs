using Services.DTOs.MotorDTOs;

namespace Repositories.Contracts;

public interface IMotorRepository
{
    Task<MotorAddDto> AddAsync(MotorAddDto motorAddDto);
    Task<List<MotorGetDto>> GetAllAsync();
    Task<MotorGetDto> GetByIdAsync(int id);
    Task<MotorUpdateDto> UpdateAsync(MotorUpdateDto motorUpdateDto);
    Task DeleteAsync(int id);
}