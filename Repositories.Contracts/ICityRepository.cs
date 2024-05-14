using Services.DTOs.CityDTOs;

namespace Repositories.Contracts;

public interface ICityRepository
{
    Task AddAsync(CityAddDto cityAddDto);
    Task<CityGetDto> GetByIdAsync(int id);
    Task<List<CityGetDto>> GetAllAsync();
    Task<List<CityGetDto>> StartsWithAsync(string recherche);
    Task UpdateAsync(CityUpdateDto cityUpdateDto);
    Task DeleteAsync(int id);

}