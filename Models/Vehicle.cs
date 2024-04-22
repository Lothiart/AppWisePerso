using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Registration", IsUnique = true)]
public class Vehicle
{
    public int Id { get; set; }

    public string Registration { get; set; }

    public int TotalSeats { get; set; }

    public int CO2EmissionKm { get; set; }

    public int StatusId { get; set; }
    public Status Status { get; set; } //faire fichier const

    public int CategoryId { get; set; }
    public Category Category { get; set; }

    public int MotorId { get; set; }
    public Motor Motor { get; set; }

    public int ModelId { get; set; }
    public Model Model { get; set; }

    public List<Carpool> Carpools { get; set; }

    public List<Rental> Rentals { get; set; }

    public int CollaboratorId { get; set; }
    public Collaborator Collaborator { get; set; }
}
