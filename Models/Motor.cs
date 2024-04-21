using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Index("Type", IsUnique = true)]

    public class Motor
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
