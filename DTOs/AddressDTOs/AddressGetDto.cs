using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AddressDTOs;
public class AddressGetDto : AddressAddDto
{
    public int Id { get; set; }
    public String City { get; set; }
}
