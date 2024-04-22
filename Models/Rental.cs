

using Microsoft.EntityFrameworkCore;

namespace Entities;
public class Rental
{
    public int Id { get; set; } //ok

    public int VehiculeId { get; set; } //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Vehicle Vehicle { get; set; } //ok

    public int CollaboratorId { get; set; } //ok
    public Collaborator Collaborator { get; set; } //ok

    public DateTime StartDateId { get; set; } //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Date StartDate { get; set; } //ok

    public DateTime EndDateId { get; set; } //ok
    public Date EndDate { get; set; } //ok
}
