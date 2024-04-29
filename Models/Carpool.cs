using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities;

public class Carpool
{
    public int Id { get; set; }

    public int EndAddressId { get; set; }
    public Address EndAddress { get; set; }

    public int StartAddressId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Address StartAddress { get; set; }

    [ForeignKey(nameof(Date))]
    public DateTime DateId { get; set; }

    public int RentalId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Rental Rental { get; set; }

    public int DriverId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public Collaborator Driver { get; set; }

    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<Collaborator> Passengers { get; set; }
}
