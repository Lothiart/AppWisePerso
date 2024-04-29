namespace DTOs.DTOs.VehicleDTOs;

public class VehicleByDateDto
{
    public DateTime StartDateId { get; set; } = DateTime.Now;
    public DateTime EndDateId { get; set; } = DateTime.Now.AddDays(2);
}
