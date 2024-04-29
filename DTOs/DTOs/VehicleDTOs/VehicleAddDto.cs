namespace Services.DTOs.VehicleDTOs;

public class VehicleAddDto
{
    public string Registration { get; set; }
    public int TotalSeats { get; set; }
    public int CO2EmissionKm { get; set; }

    public int? CategoryId { get; set; }
    public string CategoryName { get; set; }

    public int? MotorId { get; set; }
    public string MotorType { get; set; }

    public int? ModelId { get; set; }
    public string ModelName { get; set; }

    public int? BrandId { get; set; }
    public string BrandName { get; set; }
}
