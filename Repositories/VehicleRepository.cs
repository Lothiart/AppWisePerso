using DTOs.DTOs.VehicleDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class VehicleRepository(DriveWiseContext _context) : IVehicleRepository
{

    ///////////  Admin  ///////////

    public async Task<List<VehicleAdminDto>> GetAllAdminAsync()
    {
        try
        {
            List<VehicleAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Select(v => new VehicleAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                            StatusName = v.Status.Name,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleAdminDto>> GetAllByBrandAdminAsync(string brandName)
    {
        try
        {
            List<VehicleAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Model.Brand.Name == brandName)
                        .Select(v => new VehicleAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                            StatusName = v.Status.Name,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleAdminDto>> GetAllByCategoryAdminAsync(string categoryName)
    {
        try
        {
            List<VehicleAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Category.Name == categoryName)
                        .Select(v => new VehicleAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                            StatusName = v.Status.Name,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleAdminDto>> GetAllByMotorTypeAdminAsync(string motorType)
    {
        try
        {
            List<VehicleAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Motor.Type == motorType)
                        .Select(v => new VehicleAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                            StatusName = v.Status.Name,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleAdminDto>> GetAllByStatusNameAdminAsync(string statusName)
    {
        try
        {
            List<VehicleAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Status.Name == statusName)
                        .Select(v => new VehicleAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                            StatusName = v.Status.Name,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<VehicleAdminDto> GetByIdAdminAsync(int id)
    {
        try
        {
            VehicleAdminDto? currentVehicle =
                await _context
                        .Vehicles
                        .Select(v => new VehicleAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                            StatusName = v.Status.Name,
                        })
                        .FirstOrDefaultAsync(v => v.Id == id);

            return currentVehicle;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<VehicleAdminDto> AddAdminAsync(VehicleAdminDto vehicleAdminDto)
    {
        try
        {
            await _context
                    .Vehicles
                    .AddAsync(new Vehicle
                    {
                        Registration = vehicleAdminDto.Registration,
                        TotalSeats = vehicleAdminDto.TotalSeats,
                        CO2EmissionKm = vehicleAdminDto.CO2EmissionKm,
                        StatusId = vehicleAdminDto.StatusId,
                        CategoryId = (int)vehicleAdminDto.CategoryId,
                        MotorId = (int)vehicleAdminDto.MotorId,
                        ModelId = (int)vehicleAdminDto.ModelId,
                        //Brand ????
                    });

            await _context.SaveChangesAsync();
            return vehicleAdminDto;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Vehicle> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto)
    {
        try
        {
            Vehicle? vehicleToUpdate =
                await _context
                        .Vehicles
                        .FirstOrDefaultAsync(v => v.Id == vehicleUpdateDto.Id);

            if (vehicleToUpdate == null)
                return null;

            vehicleToUpdate.Registration = vehicleUpdateDto.Registration;
            vehicleToUpdate.TotalSeats = vehicleUpdateDto.TotalSeats;
            vehicleToUpdate.CO2EmissionKm = vehicleUpdateDto.CO2EmissionKm;
            vehicleToUpdate.StatusId = vehicleUpdateDto.StatusId;
            vehicleToUpdate.CategoryId = (int)vehicleUpdateDto.CategoryId;
            vehicleToUpdate.MotorId = (int)vehicleUpdateDto.MotorId;
            vehicleToUpdate.ModelId = (int)vehicleUpdateDto.ModelId;
            //Brand ????


            await _context.SaveChangesAsync();
            return vehicleToUpdate;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Vehicle> DeleteAsync(int id)
    {
        try
        {
            Vehicle? vehicleToDelete = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

            if (vehicleToDelete == null)
                return null;

            _context.Vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();
            return vehicleToDelete;

        }
        catch (Exception)
        {
            throw;
        }
    }


    ///////////  Collaborator  ///////////


    public async Task<List<VehicleGetDto>> GetAllByDatesAsync(VehicleByDateDto vehicleByDateDto)
    {
        try
        {
            List<VehicleGetDto> listVehicleGetDtos =
                await _context
                        .Rentals
                        .Where(r => ((vehicleByDateDto.EndDateId < r.StartDateId)
                                || (vehicleByDateDto.StartDateId > r.EndDateId))
                                && r.Vehicle.Status.Name == "AVAILABLE"
                                )
                        .Select(r => new VehicleGetDto
                        {
                            Id = r.Id,
                            Registration = r.Vehicle.Registration,
                            TotalSeats = r.Vehicle.TotalSeats,
                            CO2EmissionKm = r.Vehicle.CO2EmissionKm,
                            CategoryName = r.Vehicle.Category.Name,
                            MotorType = r.Vehicle.Motor.Type,
                            ModelName = r.Vehicle.Model.Name,
                            BrandName = r.Vehicle.Model.Brand.Name,
                        })
                        .ToListAsync();

            return listVehicleGetDtos;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByBrandAsync(string brandName)
    {
        try
        {
            List<VehicleGetDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Model.Brand.Name == brandName)
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,

                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByCategoryAsync(string categoryName)
    {
        try
        {
            List<VehicleGetDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Category.Name == categoryName)
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,

                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByMotorTypeAsync(string motorType)
    {
        try
        {
            List<VehicleGetDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Motor.Type == motorType)
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<VehicleGetDto> GetByIdAsync(int id)
    {
        try
        {
            VehicleGetDto? currentVehicle =
                await _context
                        .Vehicles
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryName = v.Category.Name,
                            MotorType = v.Motor.Type,
                            ModelName = v.Model.Name,
                            BrandName = v.Model.Brand.Name,
                        })
                        .FirstOrDefaultAsync(v => v.Id == id);

            return currentVehicle;
        }
        catch (Exception)
        {

            throw;
        }
    }
}