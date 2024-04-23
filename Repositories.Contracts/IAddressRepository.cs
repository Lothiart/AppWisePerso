using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface IAddressRepository
{
    Task AddAsync(AddressAddDto addressAddDto);
    Task<> GetByIdAsync(int id);
}
