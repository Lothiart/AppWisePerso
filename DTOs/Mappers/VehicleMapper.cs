using DTOs.DTOs.VehicleDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers;
public class VehicleMapper
{
    public VehicleGetDto VehicleToVehicleGetDto(Vehicle vehicle)
    {
        VehicleGetDto vehicleDto = new VehicleGetDto()
        {
            Id = vehicle.Id,
            CategoryId = vehicle.CategoryId,
            CO2EmissionKm = vehicle.CO2EmissionKm,
            ModelId = vehicle.ModelId,
            MotorId = vehicle.MotorId,
            Registration = vehicle.Registration,
            TotalSeats = vehicle.TotalSeats
        };

        return vehicleDto;  
    }
}
