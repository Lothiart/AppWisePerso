using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.CollaboratorDTOs
{
    public class CollaboratorGetPersoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public List<Carpool> CarpoolsAsDriver { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public List<Carpool> CarpoolsAsPassenger { get; set; }
        public AppUser AppUser { get; set; }
    }
}
