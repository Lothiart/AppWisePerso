using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Registration", IsUnique = true)]
public class Vehicle
{
    public int Id { get; set; } //ok

    public string Registration { get; set; } //ok

    public int TotalSeats { get; set; } //ok

    public int CO2EmissionKm { get; set; } //ok

    public int StatusId { get; set; } //ok
    public Status Status { get; set; } //faire fichier const //ok

    public int CategoryId { get; set; } //ok
    public Category Category { get; set; } //ok

    public int MotorId { get; set; } //ok
    public Motor Motor { get; set; } //ok

    public int ModelId { get; set; } //ok
    public Model Model { get; set; } //ok

    public List<Carpool> Carpools { get; set; } //ok

    public List<Rental> Rentals { get; set; } //ok

    public int CollaboratorId { get; set; } //ok
    public Collaborator Collaborator { get; set; } //ok
}
