using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities;

public class Collaborator : IdentityUser
{
    public string Name { get; set; }

    public string FirstName { get; set; }

    [ForeignKey("DriverId")]
    public List<Carpool> CarpoolsAsDriver { get; set; }

    //public List<Carpool> CarpoolsAsPassenger { get; set; }
}