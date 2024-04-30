using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Registration", IsUnique = true)]
public class Vehicle
{
    public int Id { get; set; }

    public string Registration { get; set; }

    public int TotalSeats { get; set; }

    public int CO2EmissionKm { get; set; }

    public int StatusId { get; set; } = 1;
    public Status Status { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int MotorId { get; set; }
    public Motor Motor { get; set; }

    public int ModelId { get; set; }
    public Model Model { get; set; }

    public int BrandId { get; set; }
    [DeleteBehavior(DeleteBehavior.NoAction)]

    public Brand Brand { get; set; }

    public List<Rental> Rentals { get; set; }
}
