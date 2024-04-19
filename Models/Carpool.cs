using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Carpool
    {
        public int Id { get; set; }
        public int NbPlacesRemain { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
