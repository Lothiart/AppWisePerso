namespace Services.DTOs.VehicleDTOs;

public class VehicleRentalDto : VehicleGetDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}