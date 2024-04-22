using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public class Carpool
{
    public int Id { get; set; } //ok

    public int RemainingSeats { get; set; } //ok

    public int EndAddressId { get; set; }  //ok
    public Address EndAddress { get; set; } //ok

    public int StartAddressId { get; set; }  //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Address StartAddress { get; set; } //ok

    public int DateId { get; set; } //ok
    public Date Date { get; set; } //ok

    public int vehicleId { get; set; } //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Vehicle Vehicle { get; set; } //ok
    public int DriverId { get; set; } //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Collaborator Driver { get; set; } //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<Collaborator> Passengers { get; set; } //ok
}
