using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.CarpoolDTOs;
public class CarpoolSearchDto
{
    public DateTime DateId { get; set; }
    public string StartCity { get; set; }
    public string EndCity { get; set; }
}