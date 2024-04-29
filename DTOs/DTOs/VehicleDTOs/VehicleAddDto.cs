namespace DTOs.DTOs.VehicleDTOs;

public class VehicleAddDto
{
    public string Registration { get; set; }
    public int TotalSeats { get; set; }
    public int CO2EmissionKm { get; set; }

    public int CategoryId { get; set; }
    public int MotorId { get; set; }
    public int ModelId { get; set; }
    public int BrandId { get; set; }

}
