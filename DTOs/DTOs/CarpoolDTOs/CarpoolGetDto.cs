using Services.DTOs.CollaboratorDTOs;
using Services.DTOs.VehicleDTOs;
using Services.DTOs.AddressDTOs;


namespace Services.DTOs.CarpoolDTOs;

public class CarpoolGetDto : CarpoolAddDto
{
    public int Id { get; set; }
    public CollaboratorGetDto Driver { get; set; }
    public List<CollaboratorGetDto> PassengersDto { get; set; }
    public int RemainingSeats { get; set; }
    public VehicleGetDto VehicleGetDto { get; set; }
    public AddressGetDto StartAddressDto { get; set; }
    public AddressGetDto EndAddressDto { get; set; }
}