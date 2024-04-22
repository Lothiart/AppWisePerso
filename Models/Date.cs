using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities;

public class Date
{
    [Key]
    public DateTime DayAndTime { get; set; } //ok

    public List<Carpool> Carpools { get; set; } //ok

    [ForeignKey("StartDateId")]
    public List<Rental> RentalStarts { get; set; } //ok

    [ForeignKey("EndDateId")]
    public List<Rental> RentalEnds { get; set; } //ok
}
