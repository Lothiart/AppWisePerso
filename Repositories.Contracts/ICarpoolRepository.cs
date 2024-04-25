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
    Task AddPassengerAsync(int carpoolId, int collaboratorId);
    Task DeleteAsync(int id);
    Task<CarpoolGetDto> GetByIdAsync(int id);
    Task<List<CarpoolGetDto>> GetAllAsync();
    Task<List<CarpoolGetDto>> GetByCitiesAndDateAsync(string startCity, string endCity, DateTime dateId);
    Task<List<CarpoolGetDto>> GetByUserAndDateAscAsync();
    Task Update(CarpoolUpdateDto carpoolUpdateDto);
}
