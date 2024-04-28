using DTOs.DTOs.VehicleDTOs;

namespace Repositories.Contracts;

public interface IVehicleRepository
{
    Task<VehicleAdminDto> AddAdminAsync(VehicleAdminDto vehicleAddDto);

    Task<List<VehicleGetDto>> GetAllAsync(); //ok
    Task<VehicleGetDto> GetByIdAsync(int id);//ok
    Task<List<VehicleGetDto>> GetAllModelsAsync(string param);
    Task<List<VehicleGetDto>> GetAllBrandsAsync(string param);
    Task<List<VehicleGetDto>> GetAllMotorsAsync(string param);
    Task<List<VehicleGetDto>> GetAllCategoriesAsync(string param);
    Task<List<VehicleGetDto>> GetAllAddressesAsync(string param);

    //GetallByDates

    Task<List<VehicleAdminDto>> GetAllAdminAsync();//ok
    Task<VehicleAdminDto> GetByIdAdminAsync(int id);//ok
    Task<List<VehicleAdminDto>> GetAllModelsAdminAsync(string param);
    Task<List<VehicleAdminDto>> GetAllBrandsAdminAsync(string param);
    Task<List<VehicleAdminDto>> GetAllMotorsAdminAsync(string param);
    Task<List<VehicleAdminDto>> GetAllCategoriesAdminAsync(string param);
    Task<List<VehicleAdminDto>> GetAllAddressesAdminAsync(string param);

    Task<VehicleUpdateDto> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto);

    Task DeleteAdminAsync(int id);
}