using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Address
{
    public int Id { get; set; } 

    public string Line1 { get; set; } 

    public string Line2 { get; set; } 

    public int CityId { get; set; }
    public City City { get; set; } 

    [ForeignKey("StartAddressId")]
    public List<Carpool> CarpoolStartAdresses { get; set; } 

    [ForeignKey("EndAddressId")]
    public List<Carpool> CarpoolEndAdresses { get; set; }

    public List<Vehicle> VehicleLocations { get; set; }
}
