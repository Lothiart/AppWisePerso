using Services.DTOs.RentalDTOs;
using Services.DTOs.VehicleDTOs;
using Entities;

namespace Repositories.Contracts;

public interface IRentalRepository
{
    Task<List<RentalGetDto>> GetAllFuturesAdminAsync();
    Task<List<RentalGetDto>> GetAllCurrentsAdminAsync();
    Task<List<RentalGetDto>> GetAllPastsAdminAsync();


    Task<List<RentalGetDto>> GetAllFuturesUserAsync(AppUser currentUser);
    Task<List<RentalGetDto>> GetAllCurrentsUserAsync(AppUser currentUser);
    Task<List<RentalGetDto>> GetAllPastsUserAsync(AppUser currentUser);
    Task<RentalGetDto> GetByIdAsync(int id, AppUser currentUser);
    Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto, AppUser currentUser);
    Task<RentalUpdateDto> UpdateAsync(RentalUpdateDto rentalUpdateDto, AppUser currentUser);
    Task DeleteAsync(int id, AppUser currentUser);

}
