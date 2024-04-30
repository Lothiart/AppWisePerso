using Services.DTOs.CarpoolDTOs;
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
    Task<bool> DeleteAsync(int id);
    Task<CarpoolGetDto> GetByIdAsync(int id);
    Task<List<CarpoolGetDto>> GetAllAsync();
    Task<List<CarpoolGetDto>> GetByCitiesAndDateAsync(CarpoolSearchDto carpoolSearch);
    Task<bool> UpdateAsync(CarpoolUpdateDto carpoolUpdateDto);
    Task<List<CarpoolGetDto>> GetAllAsDriverAsync(int collaboratorId);
    Task<List<CarpoolGetDto>> GetAllAsPassengerAsync(int collaboratorId);
}
