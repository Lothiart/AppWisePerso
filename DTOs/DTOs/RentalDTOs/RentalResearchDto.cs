namespace DTOs.DTOs.RentalDTOs;

public class RentalResearchDateDto
{
    public DateTime StartDateId { get; set; } = DateTime.Now;
    public DateTime EndDateId { get; set; } = DateTime.Now.AddDays(2);

}
