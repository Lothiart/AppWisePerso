using DTOs;

namespace Repositories.Contracts;

public interface IVehicleRepository
{
    Task<VehicleAddDto> AddAsync(VehicleAddDto vehicleAddDto);

    Task<List<VehicleGetDto>> GetAllAsync();
    Task<List<VehicleGetAdminDto>> GetAllAdminAsync();

    Task<VehicleGetDto> GetByParamAsync(string param);
    Task<VehicleGetAdminDto> GetByParamAdminAsync(string param);

    Task<VehicleUpdateDto> UpdateAsync(VehicleUpdateDto vehicleUpdateDto);

    Task DeleteAsync(int id);
}