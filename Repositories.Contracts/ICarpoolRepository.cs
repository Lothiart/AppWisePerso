using DTOs.CarpoolDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts;
public interface ICarpoolRepository
{
    Task AddAsync(CarpoolAddDto carpoolAddDto);
    Task<CarpoolGetDto> GetByIdAsync(int id);
    Task<List<CarpoolGetDto>> GetAllAsync();
    Task<List<CarpoolGetDto>> GetByCityAsync();
    Task<List<CarpoolGetDto>> GetByUserAndDateAsync();
    Task<List<CarpoolGetDto>> GetByCityAndDateAsync();
    Task Update(CarpoolUpdateDto carpoolUpdateDto);
    Task DeleteAsync(int id);
    Task AddPassengerAsync(int id);
}
