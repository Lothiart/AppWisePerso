using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Collaborator : IdentityUser
    {
        public string Name { get; set; }

        public string FirstName { get; set; }

        [ForeignKey("DriverId")]
        public List<Carpool> CarpoolsAsDriver { get; set; }

        //public List<Carpool> CarpoolsAsPassenger { get; set; }
    }
}