

namespace Entities;

public class Carpool
{
    public int Id { get; set; }
    public DateTime DepartureDate { get; set; }

    public int EndAddressId { get; set; }
    public Address EndAddress { get; set; }

    public int StartAddressId { get; set; }
    public Address StartAddress { get; set; }

    public Date Date { get; set; }

    public Vehicle Vehicle { get; set; }

    public string DriverId { get; set; }
    //[ForeignKey("DriverId")]
    public Collaborator Driver { get; set; }

    //public List<Collaborator> Passengers { get; set; }
}
