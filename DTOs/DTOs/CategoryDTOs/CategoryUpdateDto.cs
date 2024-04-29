using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.CategoryDTOs;
public class CategoryUpdateDto : CategoryAddDto
{
    public int Id { get; set; }
}
