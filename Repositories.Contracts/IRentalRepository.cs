using DTOs.DTOs.RentalDTOs;
using DTOs.DTOs.VehicleDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IRentalRepository
{

    Task<List<VehicleGetDto>> ResearchCarRentalAsync(RentalResearchDateDto rentalResearchDateDto);
    Task<List<RentalGetDto>> GetAllCurrentAsync();
    Task<List<RentalGetDto>> GetAllPastAsync();
    Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto);
    Task<Rental> UpdateAsync(RentalUpdateDto rentalUpdateDto);
    Task<Rental> DeleteAsync(int id);

}
