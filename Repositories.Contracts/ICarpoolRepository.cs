using Services.DTOs.CarpoolDTOs;

namespace Repositories.Contracts;
public interface ICarpoolRepository
{
    Task AddAsync(CarpoolAddDto carpoolAddDto);
    Task<bool> AddPassengerAsync(CarpoolAddPassengerDto carpoolAddPassengerDto);
    Task<bool> DeleteAsync(int id);
    Task<CarpoolGetDto> GetByIdAsync(int id);
    Task<List<CarpoolGetDto>> GetAllAsync();
    Task<List<CarpoolGetDto>> GetByCitiesAndDateAsync(CarpoolSearchDto carpoolSearch);
    Task<bool> UpdateAsync(CarpoolUpdateDto carpoolUpdateDto);
    Task<List<CarpoolGetDto>> GetAllAsDriverAsync(int collaboratorId);
    Task<List<CarpoolGetDto>> GetAllAsPassengerAsync(int collaboratorId);
}
