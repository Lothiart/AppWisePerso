using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Index("Name", IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
