using DTOs.DTOs.VehicleDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class VehicleRepository(DriveWiseContext _context) : IVehicleRepository
{
    public async Task<List<VehicleAdminDto>> GetAllAdminAsync()
    {
        List<Vehicle> allVehicles = await _context.Vehicles.ToListAsync();

        if (allVehicles == null)
            return null;

        List<VehicleAdminDto> listVehiclesDto = new List<VehicleAdminDto>();

        foreach (Vehicle vehicle in allVehicles)
        {
            VehicleAdminDto allVehiclesDto = new VehicleAdminDto
            {
                Id = vehicle.Id,
                Registration = vehicle.Registration,
                TotalSeats = vehicle.TotalSeats,
                CO2EmissionKm = vehicle.CO2EmissionKm,
                CategoryId = vehicle.CategoryId,
                MotorId = vehicle.MotorId,
                ModelId = vehicle.ModelId,
                StatusId = vehicle.StatusId,
            };
            listVehiclesDto.Add(allVehiclesDto);
        }
        return listVehiclesDto;
    }

    public async Task<List<VehicleGetDto>> GetAllAsync()
    {
        List<Vehicle> allVehicles = await _context.Vehicles.ToListAsync();

        if (allVehicles == null)
            return null;

        List<VehicleGetDto> listVehiclesDto = new List<VehicleGetDto>();

        foreach (Vehicle vehicle in allVehicles)
        {
            VehicleGetDto allVehiclesDto = new VehicleGetDto
            {
                Id = vehicle.Id,
                Registration = vehicle.Registration,
                TotalSeats = vehicle.TotalSeats,
                CO2EmissionKm = vehicle.CO2EmissionKm,
                CategoryId = vehicle.CategoryId,
                MotorId = vehicle.MotorId,
                ModelId = vehicle.ModelId,
            };
            listVehiclesDto.Add(allVehiclesDto);
        }
        return listVehiclesDto;
    }

    public async Task<VehicleAdminDto> GetByIdAdminAsync(int id)
    {
        Vehicle currentVehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

        if (currentVehicle == null)
            return null;

        VehicleAdminDto oneVehicleDto = new VehicleAdminDto
        {
            Id = currentVehicle.Id,
            Registration = currentVehicle.Registration,
            TotalSeats = currentVehicle.TotalSeats,
            CO2EmissionKm = currentVehicle.CO2EmissionKm,
            CategoryId = currentVehicle.CategoryId,
            MotorId = currentVehicle.MotorId,
            ModelId = currentVehicle.ModelId,
            StatusId = currentVehicle.StatusId,
        };
        return oneVehicleDto;
    }

    public async Task<VehicleGetDto> GetByIdAsync(int id)
    {
        Vehicle currentVehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);

        if (currentVehicle == null)
            return null;

        VehicleGetDto oneVehicleDto = new VehicleGetDto
        {
            Id = currentVehicle.Id,
            Registration = currentVehicle.Registration,
            TotalSeats = currentVehicle.TotalSeats,
            CO2EmissionKm = currentVehicle.CO2EmissionKm,
            CategoryId = currentVehicle.CategoryId,
            MotorId = currentVehicle.MotorId,
            ModelId = currentVehicle.ModelId,
        };
        return oneVehicleDto;
    }

    public async Task<VehicleAdminDto> AddAdminAsync(VehicleAdminDto vehicleAddDto)
    {

        try
        {
            await _context.Vehicles.AddAsync(new Vehicle
            {
                Registration = vehicleAddDto.Registration,
                TotalSeats = vehicleAddDto.TotalSeats,
                CO2EmissionKm = vehicleAddDto.CO2EmissionKm,
                CategoryId = vehicleAddDto.CategoryId,
                MotorId = vehicleAddDto.MotorId,
                ModelId = vehicleAddDto.ModelId,
                StatusId = vehicleAddDto.StatusId,
            });

            await _context.SaveChangesAsync();
            return vehicleAddDto;

        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<List<VehicleAdminDto>> GetAllAddressesAdminAsync(string param)
    {
        // List<VehicleAdminDto> allVehiclesByAdresses = await _context.Vehicles.Include(v => v.

        // entité vehicle n'a pas d'addresses
        throw new NotImplementedException();

    }

    public async Task<List<VehicleGetDto>> GetAllAddressesAsync(string param)
    {
        throw new NotImplementedException();
    }


    public async Task<List<VehicleAdminDto>> GetAllBrandsAdminAsync(string param)
    {
        List<Vehicle> allVehiclesByBrand = await _context
                                                     .Vehicles
                                                     .Where(v => v.Model.Brand.Name == param)
                                                     .ToListAsync();

        if (allVehiclesByBrand == null)
            return null;

        List<VehicleAdminDto> listVehiclesDto = new List<VehicleAdminDto>();

        foreach (Vehicle vehicle in allVehiclesByBrand)
        {
            VehicleAdminDto allVehiclesDto = new VehicleAdminDto
            {
                Id = vehicle.Id,
                Registration = vehicle.Registration,
                TotalSeats = vehicle.TotalSeats,
                CO2EmissionKm = vehicle.CO2EmissionKm,
                CategoryId = vehicle.CategoryId,
                MotorId = vehicle.MotorId,
                ModelId = vehicle.ModelId,
                StatusId = vehicle.StatusId,
            };
            listVehiclesDto.Add(allVehiclesDto);
        }
        return listVehiclesDto;
    }

    public async Task<List<VehicleGetDto>> GetAllBrandsAsync(string param)
    {
        throw new NotImplementedException();
    }

    public async Task<List<VehicleAdminDto>> GetAllCategoriesAdminAsync(string param)
    {
        List<Vehicle> allVehiclesByAdresses = await _context
                                                        .Vehicles
                                                        .Where(v => v.Category.Name == param)
                                                        .ToListAsync();

        if (allVehiclesByAdresses == null)
            return null;


        List<VehicleAdminDto> listVehiclesDto = new List<VehicleAdminDto>();

        foreach (Vehicle vehicle in allVehiclesByAdresses)
        {
            VehicleAdminDto allVehiclesDto = new VehicleAdminDto
            {
                Id = vehicle.Id,
                Registration = vehicle.Registration,
                TotalSeats = vehicle.TotalSeats,
                CO2EmissionKm = vehicle.CO2EmissionKm,
                CategoryId = vehicle.CategoryId,// inutile ->faire un nouveau dto
                MotorId = vehicle.MotorId,
                ModelId = vehicle.ModelId,
                StatusId = vehicle.StatusId,
            };
            listVehiclesDto.Add(allVehiclesDto);
        }
        return listVehiclesDto;

    }

    public async Task<List<VehicleGetDto>> GetAllCategoriesAsync(string param)
    {
        throw new NotImplementedException();
    }

    public async Task<List<VehicleAdminDto>> GetAllModelsAdminAsync(string param)
    {
        throw new NotImplementedException();
    }

    public async Task<List<VehicleGetDto>> GetAllModelsAsync(string param)
    {
        throw new NotImplementedException();
    }

    public async Task<List<VehicleAdminDto>> GetAllMotorsAdminAsync(string param)
    {
        throw new NotImplementedException();
    }

    public async Task<List<VehicleGetDto>> GetAllMotorsAsync(string param)
    {
        throw new NotImplementedException();
    }


    public async Task<VehicleUpdateDto> UpdateAdminAsync(VehicleUpdateDto vehicleUpdateDto)
    {
        throw new NotImplementedException();
    }
    public async Task DeleteAdminAsync(int id)
    {
        throw new NotImplementedException();
    }
}
