using DTOs.DTOs.RentalDTOs;
using DTOs.DTOs.VehicleDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IRentalRepository
{
    Task<List<RentalGetDto>> GetAllCurrentAsync();
    Task<List<RentalGetDto>> GetAllPastAsync();

    // Task<RentalGetDto> GetByIdAsync(int id);

    Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto);
    Task<Rental> UpdateAsync(RentalUpdateDto rentalUpdateDto);
    Task<Rental> DeleteAsync(int id);

}
