using DTOs.DTOs.AddressDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface IAddressRepository
{
    Task<AddressAddDto> AddAsync(AddressAddDto addressAddDto);
    Task<AddressGetDto> GetByIdAsync(int id);
    Task<AddressUpdateDto> UpdateAsync(AddressUpdateDto addressUpdateDto);
    Task<Address> DeleteAsync(int id);
}
