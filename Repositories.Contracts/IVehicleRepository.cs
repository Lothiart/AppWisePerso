using Services.DTOs.VehicleDTOs;

namespace Repositories.Contracts;

public interface IVehicleRepository
{
    Task<List<VehicleGetAdminDto>> GetAllAdminAsync();
    Task<List<VehicleGetAdminDto>> GetAllByBrandIdAdminAsync(int id);
    Task<List<VehicleGetAdminDto>> GetAllByCategoryIdAdminAsync(int id);
    Task<List<VehicleGetAdminDto>> GetAllByMotorIdAdminAsync(int id);
    Task<List<VehicleGetAdminDto>> GetAllByStatusIdAdminAsync(int id);
    Task<VehicleGetAdminDto> GetByIdAdminAsync(int id);
    Task<VehicleAdminDto> AddAdminAsync(VehicleAdminDto vehicleGetAdminDto);
    Task<VehicleUpdateDto> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto);
    Task DeleteAdminAsync(int id);
    Task<List<VehicleRentalDto>> GetAllByDatesAsync(VehicleByDateDto vehicleByDateDto);
    Task<List<VehicleGetDto>> GetAllByBrandIdAsync(int id);
    Task<List<VehicleGetDto>> GetAllByCategoryIdAsync(int id);
    Task<List<VehicleGetDto>> GetAllByMotorIdAsync(int id);
    Task<VehicleGetDto> GetByIdAsync(int id);
}