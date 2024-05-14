using Services.DTOs.CarpoolDTOs;
using Entities;

namespace DTOs.Mappers;

public class CarpoolMapper(CollaboratorMapper collaboratorMapper,
                            VehicleMapper vehicleMapper,
                            AddressMapper addressMapper)
{

    #region EntityToDto
    public List<CarpoolGetDto> ListCarpoolToListCarpoolGetDto(List<Carpool> carpools)
    {
        List<CarpoolGetDto> carpoolDtos = new();

        foreach (Carpool carpool in carpools)
        {
            carpoolDtos.Add(CarpoolToCarpoolGetDto(carpool));
        }

        return carpoolDtos;
    }

    public CarpoolGetDto CarpoolToCarpoolGetDto(Carpool carpool)
    {
        CarpoolGetDto carpoolDto = new CarpoolGetDto()
        {
            Id = carpool.Id,
            DriverId = carpool.DriverId,
            Driver = collaboratorMapper.CollaboratorToCollaboratorGetDto(carpool.Driver),
            DateId = carpool.DateId,
            VehicleGetDto = vehicleMapper.VehicleToVehicleGetDto(carpool.Rental.Vehicle),
            RemainingSeats = carpool.Rental.Vehicle.TotalSeats - carpool.Passengers.Count - 1, //-1 = driver seat
            StartAddressDto = addressMapper.AddressToAddressGetDto(carpool.StartAddress),
            EndAddressDto = addressMapper.AddressToAddressGetDto(carpool.EndAddress),
            PassengersDto = collaboratorMapper.ListCollaboratorToListCollaboratorGetDto(carpool.Passengers),
        };

        return carpoolDto;
    }

    #endregion


    #region DtoToEntity

    public Carpool CarpoolAddDtoToCarpool(CarpoolAddDto carpoolDto)
    {
        Carpool c = new Carpool()
        {
            DateId = carpoolDto.DateId,
            DriverId = carpoolDto.DriverId,
            EndAddressId = carpoolDto.EndAddressId,
            StartAddressId = carpoolDto.StartAddressId,
            RentalId = carpoolDto.RentalId,
        };

        return c;
    }

    #endregion
}