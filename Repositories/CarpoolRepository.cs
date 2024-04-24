using DTOs.CarpoolDTOs;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class CarpoolRepository : ICarpoolRepository
{
    public Task AddAsync(CarpoolAddDto carpoolAddDto)
    {
        throw new NotImplementedException();
    }

    public Task AddPassengerAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CarpoolGetDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<CarpoolGetDto>> GetByCityAndDateAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<CarpoolGetDto>> GetByCityAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CarpoolGetDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CarpoolGetDto>> GetByUserAndDateAsync()
    {
        throw new NotImplementedException();
    }

    public Task Update(CarpoolUpdateDto carpoolUpdateDto)
    {
        throw new NotImplementedException();
    }
}
