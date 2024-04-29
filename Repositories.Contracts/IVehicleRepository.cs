using DTOs.DTOs.VehicleDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IVehicleRepository
{
    Task<List<VehicleAdminDto>> GetAllAdminAsync();
    Task<List<VehicleAdminDto>> GetAllByBrandAdminAsync(string brandName);
    Task<List<VehicleAdminDto>> GetAllByCategoryAdminAsync(string categoryName);
    Task<List<VehicleAdminDto>> GetAllByMotorTypeAdminAsync(string motorType);
    Task<List<VehicleAdminDto>> GetAllByStatusNameAdminAsync(string statusName);
    Task<VehicleAdminDto> GetByIdAdminAsync(int id);
    Task<VehicleAdminDto> AddAdminAsync(VehicleAdminDto vehicleAdminDto);
    Task<Vehicle> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto);
    Task<Vehicle> DeleteAsync(int id);
    Task<List<VehicleGetDto>> GetAllByDatesAsync(VehicleByDateDto vehicleByDateDto);
    Task<List<VehicleGetDto>> GetAllByBrandAsync(string brandName);
    Task<List<VehicleGetDto>> GetAllByCategoryAsync(string categoryName);
    Task<List<VehicleGetDto>> GetAllByMotorTypeAsync(string motorType);
    Task<VehicleGetDto> GetByIdAsync(int id);







}