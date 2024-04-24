using DTOs.AddressDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface IAddressRepository
{
    Task AddAsync(AddressAddDto addressAddDto);
    Task<AddressGetDto> GetByIdAsync(int id);
    Task Update(AddressUpdateDto addressUpdateDto);
    Task DeleteByIdAsync(int id);
}
