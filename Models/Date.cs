using System.ComponentModel.DataAnnotations.Schema;


namespace Entities;

public class Date
{
    public DateTime Id { get; set; }

    public List<Carpool> Carpools { get; set; }

    [ForeignKey("StartDateId")]
    public List<Rental> RentalStarts { get; set; }

    [ForeignKey("EndDateId")]
    public List<Rental> RentalEnds { get; set; }
}