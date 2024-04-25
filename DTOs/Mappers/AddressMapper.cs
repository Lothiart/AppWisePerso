using DTOs.DTOs.AddressDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers;
public class AddressMapper
{
    public AddressGetDto AddressToAddressGetDto(Address address)
    {
        AddressGetDto addressDTOs = new AddressGetDto()
        {
            Line1 = address.Line1,
            Line2 = address.Line2,
            City = address.City.Name,
            CityId = address.CityId,
        };

        return addressDTOs;
    }
}
