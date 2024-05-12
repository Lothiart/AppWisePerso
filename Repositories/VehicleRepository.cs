using Services.DTOs.VehicleDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace Repositories;

public class VehicleRepository(DriveWiseContext _context, ILogger<VehicleRepository> logger) : IVehicleRepository
{

    ///////////  Admin  ///////////

    #region For Admins

    public async Task<List<VehicleGetAdminDto>> GetAllAdminAsync()
    {
        try
        {
            List<VehicleGetAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Select(v => new VehicleGetAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles");
            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByBrandIdAdminAsync(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Model.Brand.Id == id)
                        .Select(v => new VehicleGetAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by brand's id");
            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByCategoryIdAdminAsync(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Category.Id == id)
                        .Select(v => new VehicleGetAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by category's id");
            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByMotorIdAdminAsync(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Motor.Id == id)
                        .Select(v => new VehicleGetAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by motor's id");
            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByStatusIdAdminAsync(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Status.Id == id)
                        .Select(v => new VehicleGetAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by status id");
            throw;
        }
    }


    public async Task<VehicleGetAdminDto> GetByIdAdminAsync(int id)
    {
        try
        {
            VehicleGetAdminDto currentVehicle =
                await _context
                        .Vehicles
                        .Select(v => new VehicleGetAdminDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            StatusId = v.Status.Id,
                        })
                        .FirstOrDefaultAsync(v => v.Id == id) ??
                            throw new KeyNotFoundException($"No vehicle found for the provided Id {id}");

            return currentVehicle;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching vehicle by Id");
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
                        CategoryId = vehicleAdminDto.CategoryId,
                        MotorId = vehicleAdminDto.MotorId,
                        ModelId = vehicleAdminDto.ModelId,
                    });

            await _context.SaveChangesAsync();
            return vehicleAdminDto;
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The vehicle's registration {vehicleAdminDto.Registration} is unique and already exist in database");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while adding the vehicle");
            throw;
        }
    }


    public async Task<VehicleUpdateDto> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto)
    {
        try
        {
            Vehicle vehicleToUpdate =
                await _context
                        .Vehicles
                        .FirstOrDefaultAsync(v => v.Id == vehicleUpdateDto.Id) ??
                            throw new KeyNotFoundException($"No vehicle found for the provided Id {vehicleUpdateDto.Id}");

            vehicleToUpdate.Registration = vehicleUpdateDto.Registration;
            vehicleToUpdate.TotalSeats = vehicleUpdateDto.TotalSeats;
            vehicleToUpdate.CO2EmissionKm = vehicleUpdateDto.CO2EmissionKm;
            vehicleToUpdate.StatusId = vehicleUpdateDto.StatusId;
            vehicleToUpdate.CategoryId = vehicleUpdateDto.CategoryId;
            vehicleToUpdate.MotorId = vehicleUpdateDto.MotorId;
            vehicleToUpdate.ModelId = vehicleUpdateDto.ModelId;

            await _context.SaveChangesAsync();
            return vehicleUpdateDto;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The vehicle registration {vehicleUpdateDto.Registration} is unique and already exist in database");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating the vehicle");
            throw;
        }
    }


    public async Task DeleteAdminAsync(int id)
    {
        try
        {
            Vehicle vehicleToDelete =
                await _context
                        .Vehicles
                        .FirstOrDefaultAsync(v => v.Id == id) ??
                            throw new KeyNotFoundException($"No vehicle found for the provided Id {id}");

            _context.Vehicles.Remove(vehicleToDelete);
            await _context.SaveChangesAsync();

        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the vehicle");
            throw;
        }
    }

    #endregion

    ///////////  Collaborator  ///////////

    #region For Collaborators

    public async Task<List<VehicleRentalDto>> GetAllByDatesAsync(VehicleByDateDto vehicleByDateDto)
    {
        try
        {
            List<VehicleRentalDto> listVehicleRentalDto =
                await _context.Vehicles
                    .Where(v => v.StatusId == 1)
                    .Where(v => !v.Rentals.Any(r =>
                        r.VehicleId == v.Id &&
                        ((vehicleByDateDto.StartDateId >= r.StartDateId && vehicleByDateDto.StartDateId <= r.EndDateId) ||
                        (vehicleByDateDto.EndDateId >= r.StartDateId && vehicleByDateDto.EndDateId <= r.EndDateId) ||
                        (vehicleByDateDto.StartDateId <= r.StartDateId && vehicleByDateDto.EndDateId >= r.EndDateId))))
                    .Select(v => new VehicleRentalDto
                    {
                        Id = v.Id,
                        Registration = v.Registration,
                        TotalSeats = v.TotalSeats,
                        CO2EmissionKm = v.CO2EmissionKm,
                        CategoryId = v.Category.Id,
                        MotorId = v.Motor.Id,
                        ModelId = v.Model.Id,
                        StartDate = vehicleByDateDto.StartDateId,
                        EndDate = vehicleByDateDto.EndDateId,
                    })
                    .ToListAsync();

            return listVehicleRentalDto;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching available vehicles");
            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByBrandIdAsync(int id)
    {
        try
        {
            List<VehicleGetDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Model.Brand.Id == id)
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by brand's Id");
            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByCategoryIdAsync(int id)
    {
        try
        {
            List<VehicleGetDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Category.Id == id)
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by category's Id");
            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByMotorIdAsync(int id)
    {
        try
        {
            List<VehicleGetDto> listAllVehicles =
                await _context
                        .Vehicles
                        .Where(v => v.Motor.Id == id)
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by motor's Id");
            throw;
        }
    }


    public async Task<VehicleGetDto> GetByIdAsync(int id)
    {
        try
        {
            VehicleGetDto currentVehicle =
                await _context
                        .Vehicles
                        .Select(v => new VehicleGetDto
                        {
                            Id = v.Id,
                            Registration = v.Registration,
                            TotalSeats = v.TotalSeats,
                            CO2EmissionKm = v.CO2EmissionKm,
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                        })
                        .FirstOrDefaultAsync(v => v.Id == id) ??
                            throw new KeyNotFoundException($"No vehicle found for the provided Id {id}");

            return currentVehicle;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching vehicle by Id");
            throw;
        }
    }

    #endregion

}