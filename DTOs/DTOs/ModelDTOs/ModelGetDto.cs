using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.ModelDTOs
{
    public class ModelGetDto : ModelAddDto
    {
        public int Id { get; set; }
    }
}
