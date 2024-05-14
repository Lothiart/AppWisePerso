namespace Services.DTOs.VehicleDTOs;

public class VehicleTempDto : VehicleGetDto
{
    public string CategoryName { get; set; }
    public string MotorType { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
}