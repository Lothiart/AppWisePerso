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
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set;}

        public int ModelId { get; set; }

        public Model Model { get; set; }
    }
}
