namespace Services.DTOs.VehicleDTOs;

public class VehicleAdminDto : VehicleGetDto
{
    public int StatusId { get; set; }
    public string StatusName { get; set; }
}

