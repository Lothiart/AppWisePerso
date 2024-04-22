using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Address
{
    public int Id { get; set; }  //ok
    public string Line1 { get; set; }  //ok
    public string Line2 { get; set; }  //ok

    public int CityId { get; set; } //ok
    public City City { get; set; }  //ok

    [ForeignKey("StartAddressId")]
    public List<Carpool> CarpoolStartAdresses { get; set; }  //ok

    [ForeignKey("EndAddressId")]
    public List<Carpool> CarpoolEndAdresses { get; set; } //ok

    public List<Collaborator> CollaboratorAdresses { get; set; }  //ok

    public List<Vehicle> VehicleLocations { get; set; } //ok
}
