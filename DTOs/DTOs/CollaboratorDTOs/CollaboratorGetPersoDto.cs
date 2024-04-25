using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.CollaboratorDTOs
{
    public class CollaboratorGetPersoDto
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public List<Carpool> CarpoolsAsDriver { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public List<Carpool> CarpoolsAsPassenger { get; set; }
        public AppUser AppUser { get; set; }
    }
}
