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
    Task<List<CarpoolGetDto>> GetByUserAndDateAscAsync(int userId);
    Task<bool> UpdateAsync(CarpoolUpdateDto carpoolUpdateDto);
}
