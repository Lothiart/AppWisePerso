namespace Services.DTOs.RentalDTOs;

public class RentalGetDto
{
    public int Id { get; set; }
    public int DriverId { get; set; }
    public string ModelName { get; set; }
    public string BrandName { get; set; }
    public string Registration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}