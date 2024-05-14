using Services.DTOs.AddressDTOs;
using Entities;


namespace Repositories.Contracts;
public interface IAddressRepository
{
    Task<AddressAddDto> AddAsync(AddressAddDto addressAddDto);
    Task<AddressGetDto> GetByIdAsync(int id);
    Task<AddressUpdateDto> UpdateAsync(AddressUpdateDto addressUpdateDto);
    Task<Address> DeleteAsync(int id);
}
