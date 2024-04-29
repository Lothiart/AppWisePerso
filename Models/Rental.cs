using Microsoft.EntityFrameworkCore;

namespace Entities;
public class Rental
{
    public int Id { get; set; }

    public int VehicleId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Vehicle Vehicle { get; set; }

    public int CollaboratorId { get; set; }
    public Collaborator Collaborator { get; set; }

    public DateTime StartDateId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Date StartDate { get; set; }

    public DateTime EndDateId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Date EndDate { get; set; }

    public List<Carpool> Carpools { get; set; }
}
