using DTOs;

namespace Repositories.Contracts;

public interface IRentalRepository
{
    Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto);
    Task<List<RentalGetDto>> GetAllAsync();
    Task<List<RentalGetDto>> GetAllByUserAsync();
    Task<RentalGetDto> GetByIdAsync(int id);
    Task<RentalUpdateDto> UpdateAsync();
    Task DeleteAsync(int id);
}
