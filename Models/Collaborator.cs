using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities;

public class Collaborator
{

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; } // Pourquoi un name et un firstname ?
    // public string email { get; set; }  <-- Identity


    // public Role role{ get; set; }  <-- Identity

    public int AddressId { get; set; } //ok
    public Address Address { get; set; } //ok

    public List<Vehicle> Vehicles { get; set; } //ok

    public List<Rental> Rentals { get; set; } //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<Carpool> CarpoolsAsDriver { get; set; }  //ok
    [DeleteBehavior(DeleteBehavior.NoAction)]
    public List<Carpool> CarpoolsAsPassenger { get; set; } //ok
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}