using Entities;

namespace Services.DTOs.RentalDTOs;

public class RentalAddDto
{
    public int VehicleId { get; set; }

    public int CollaboratorId { get; set; }

    public DateTime StartDateId { get; set; }
    public Date StartDate { get; set; }

    public DateTime EndDateId { get; set; }
    public Date EndDate { get; set; }

}
