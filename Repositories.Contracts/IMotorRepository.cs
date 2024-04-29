using Services.DTOs.MotorDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IMotorRepository
{
    Task<MotorAddDto> AddAsync(MotorAddDto motorAddDto);
    Task<List<MotorGetDto>> GetAllAsync();
    Task<MotorGetDto> GetByIdAsync(int id);
    Task<Motor> UpdateAsync(MotorUpdateDto motorUpdateDto);
    Task<Motor> DeleteAsync(int id);
}