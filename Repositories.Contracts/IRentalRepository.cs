using DTOs;
using Entities;

namespace Repositories.Contracts;

public interface IRentalRepository
{
    Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto);
    Task<List<RentalGetDto>> GetAllAsync();
    Task<List<RentalGetDto>> GetAllByUserAsync(int id);
    Task<RentalGetDto> GetByIdAsync(int id);
    Task<RentalUpdateDto> UpdateAsync(RentalUpdateDto rentalUpdateDto);
    Task<Rental> DeleteAsync(int id);
}
