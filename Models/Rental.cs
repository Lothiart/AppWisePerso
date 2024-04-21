using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;
public class Rental
{
    public int Id { get; set; }

    public int VehiculeId { get; set; }
    public Vehicle Vehicle { get; set; }

    public int CollaboratorId { get; set; }
    public Collaborator Collaborator { get; set; }

    public int StartDateId { get; set; }
    public Date StartDate { get; set; }

    public int EndDateId { get; set; }
    public Date EndDate { get; set; }
}
