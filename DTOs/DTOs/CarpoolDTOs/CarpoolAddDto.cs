using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.CarpoolDTOs;
public class CarpoolAddDto
{
    public int EndAddressId { get; set; }
    public int StartAddressId { get; set; }
    public DateTime DateId { get; set; }
    public int RentalId { get; set; }
    public int DriverId { get; set; }
}
