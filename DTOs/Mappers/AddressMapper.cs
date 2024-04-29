using Entities;
using Services.DTOs.AddressDTOs;


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
