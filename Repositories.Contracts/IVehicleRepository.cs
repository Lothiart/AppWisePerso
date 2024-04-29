using DTOs.DTOs.VehicleDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IVehicleRepository
{
    Task<List<VehicleGetAdminDto>> GetAllAdminAsync();
    Task<List<VehicleGetAdminDto>> GetAllByBrandAdminAsync(int id);
    Task<List<VehicleGetAdminDto>> GetAllByCategoryAdminAsync(int id);
    Task<List<VehicleGetAdminDto>> GetAllByMotorTypeAdminAsync(int id);
    Task<List<VehicleGetAdminDto>> GetAllByStatusNameAdminAsync(int id);
    Task<VehicleGetAdminDto> GetByIdAdminAsync(int id);
    Task<VehicleAdminDto> AddAdminAsync(VehicleAdminDto vehicleGetAdminDto);
    Task<Vehicle> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto);
    Task<Vehicle> DeleteAdminAsync(int id);
    Task<List<VehicleGetDto>> GetAllByDatesAsync(VehicleByDateDto vehicleByDateDto);
    Task<List<VehicleGetDto>> GetAllByBrandAsync(int id);
    Task<List<VehicleGetDto>> GetAllByCategoryAsync(int id);
    Task<List<VehicleGetDto>> GetAllByMotorTypeAsync(int id);
    Task<VehicleGetDto> GetByIdAsync(int id);







}