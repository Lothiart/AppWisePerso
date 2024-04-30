using Services.DTOs.VehicleDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class VehicleRepository(DriveWiseContext _context) : IVehicleRepository
{

    ///////////  Admin  ///////////

    #region Admin

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
                            BrandId = v.Model.Brand.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByBrandAdminAsync(int id)
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
                            BrandId = v.Model.Brand.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByCategoryAdminAsync(int id)
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
                            BrandId = v.Model.Brand.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByMotorTypeAdminAsync(int id)
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
                            BrandId = v.Model.Brand.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetAdminDto>> GetAllByStatusNameAdminAsync(int id)
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
                            BrandId = v.Model.Brand.Id,
                            StatusId = v.Status.Id,
                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<VehicleGetAdminDto> GetByIdAdminAsync(int id)
    {
        try
        {
            VehicleGetAdminDto? currentVehicle =
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
                            BrandId = v.Model.Brand.Id,
                            StatusId = v.Status.Id,
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
                        StatusId = vehicleAdminDto.StatusId,// 1
                        CategoryId = (int)vehicleAdminDto.CategoryId,
                        MotorId = (int)vehicleAdminDto.MotorId,
                        ModelId = (int)vehicleAdminDto.ModelId,
                        BrandId = (int)vehicleAdminDto.BrandId,
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
            vehicleToUpdate.BrandId = (int)vehicleUpdateDto.BrandId;


            await _context.SaveChangesAsync();
            return vehicleToUpdate;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Vehicle> DeleteAdminAsync(int id)
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

    #endregion

    ///////////  Collaborator  ///////////

    #region Collaborator

    public async Task<List<VehicleGetDto>> GetAllByDatesAsync(VehicleByDateDto vehicleByDateDto)
    {
        try
        {
            List<VehicleGetDto> listVehicleGetDtos =
                await (
                    from vehicle in _context.Vehicles
                    join rental in _context.Rentals
                    on vehicle.Id equals rental.VehicleId into joined
                    from r in joined.DefaultIfEmpty()
                    where
                        ((r == null) ||
                        (vehicleByDateDto.EndDateId < r.StartDateId) ||
                        (vehicleByDateDto.StartDateId > r.EndDateId)) &&
                        vehicle.Status != null &&
                        vehicle.Status.Id == 1
                    select new VehicleGetDto
                    {
                        Id = vehicle.Id,
                        Registration = vehicle.Registration,
                        TotalSeats = vehicle.TotalSeats,
                        CO2EmissionKm = vehicle.CO2EmissionKm,
                        CategoryId = vehicle.Category.Id,
                        MotorId = vehicle.Motor.Id,
                        ModelId = vehicle.Model.Id,
                        BrandId = vehicle.Model.Brand.Id,
                    }
                ).ToListAsync();













            // await _context.Vehicles
            //     .GroupJoin(
            //         _context.Rentals,
            //         vehicle => vehicle.Id,
            //         rental => rental.VehicleId,
            //         (vehicle, joined) => new { vehicle, joined }
            //     )
            //     .SelectMany(
            //         group => group.joined.DefaultIfEmpty(),
            //         (group, j) => new { Vehicle = group.vehicle, Rental = j }
            //     )
            //     .Where(x =>
            //         ((x.Rental == null) ||
            //         (vehicleByDateDto.EndDateId < x.Rental.StartDateId) ||
            //          (vehicleByDateDto.StartDateId > x.Rental.EndDateId)) &&
            //         x.Vehicle.Status.Id == 1
            //     )
            //     .Select(x => new VehicleGetDto
            //     {
            //         Id = x.Vehicle.Id,
            //         Registration = x.Vehicle.Registration,
            //         TotalSeats = x.Vehicle.TotalSeats,
            //         CO2EmissionKm = x.Vehicle.CO2EmissionKm,
            //         CategoryId = x.Vehicle.Category.Id,
            //         MotorId = x.Vehicle.Motor.Id,
            //         ModelId = x.Vehicle.Model.Id,
            //         BrandId = x.Vehicle.Model.Brand.Id,
            //     })
            //     .ToListAsync();


















            // await _context
            //         .Rentals
            //         .Where(r => ((vehicleByDateDto.EndDateId < r.StartDateId)
            //                 || (vehicleByDateDto.StartDateId > r.EndDateId))
            //                 && r.Vehicle.Status.Id == 1
            //                 )
            //         .Select(r => new VehicleGetDto
            //         {
            //             Id = r.Id,
            //             Registration = r.Vehicle.Registration,
            //             TotalSeats = r.Vehicle.TotalSeats,
            //             CO2EmissionKm = r.Vehicle.CO2EmissionKm,
            //             CategoryId = r.Vehicle.Category.Id,
            //             MotorId = r.Vehicle.Motor.Id,
            //             ModelId = r.Vehicle.Model.Id,
            //             BrandId = r.Vehicle.Model.Brand.Id,

            //         })
            //     .ToListAsync();

            return listVehicleGetDtos;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByBrandAsync(int id)
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
                            BrandId = v.Model.Brand.Id,

                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByCategoryAsync(int id)
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
                            BrandId = v.Model.Brand.Id,

                        })
                        .ToListAsync();

            return listAllVehicles;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleGetDto>> GetAllByMotorTypeAsync(int id)
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
                            BrandId = v.Model.Brand.Id,
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
                            CategoryId = v.Category.Id,
                            MotorId = v.Motor.Id,
                            ModelId = v.Model.Id,
                            BrandId = v.Model.Brand.Id,
                        })
                        .FirstOrDefaultAsync(v => v.Id == id);

            return currentVehicle;
        }
        catch (Exception)
        {

            throw;
        }
    }

    #endregion

}