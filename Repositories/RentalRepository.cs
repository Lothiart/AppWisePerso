using Services.DTOs.RentalDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.DTOs.DateDTOs;
using Services.DTOs.VehicleDTOs;
using Microsoft.Extensions.Logging;

namespace Repositories;

public class RentalRepository(DriveWiseContext _context, IDateRepository dateRepository, IVehicleRepository vehicleRepository, ILogger<RentalRepository> logger) : IRentalRepository
{

    ///////// ADMIN /////////

    public async Task<List<RentalGetDto>> GetAllCurrentsAdminAsync()
    {
        try
        {
            List<RentalGetDto> listAllCurrent =
                await _context
                    .Rentals
                    .Where(r => r.StartDateId < DateTime.Now && r.EndDateId > DateTime.Now)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = r.CollaboratorId,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .ToListAsync();

            return listAllCurrent;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the currents rentals");
            throw;
        }
    }

    public async Task<List<RentalGetDto>> GetAllPastsAdminAsync()
    {
        try
        {
            List<RentalGetDto> listAllPast =
                await _context
                    .Rentals
                    .Where(r => r.EndDateId < DateTime.Now)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = r.CollaboratorId,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .ToListAsync();

            return listAllPast;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the pasts rentals");
            throw;
        }
    }

    public async Task<List<RentalGetDto>> GetAllFuturesAdminAsync()
    {
        try
        {
            List<RentalGetDto> listAllFuture =
                await _context
                    .Rentals
                    .Where(r => r.StartDateId > DateTime.Now)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = r.CollaboratorId,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .ToListAsync();

            return listAllFuture;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the futures rentals");
            throw;
        }
    }


    ///////// COLLABORATOR /////////


    public async Task<List<RentalGetDto>> GetAllCurrentsUserAsync(AppUser currentUser)
    {
        try
        {
            List<RentalGetDto> listAllCurrent =
                await _context
                    .Rentals
                    .Where(r => r.CollaboratorId == currentUser.Collaborator.Id && r.EndDateId > DateTime.Now && r.StartDateId < DateTime.Now)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = currentUser.Collaborator.Id,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .ToListAsync();

            return listAllCurrent;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching your currents rentals");
            throw;
        }
    }


    public async Task<List<RentalGetDto>> GetAllPastsUserAsync(AppUser currentUser)
    {
        try
        {
            List<RentalGetDto> listAllPast =
                await _context
                    .Rentals
                    .Where(r => r.CollaboratorId == currentUser.Collaborator.Id && r.EndDateId < DateTime.Now)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = currentUser.Collaborator.Id,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .ToListAsync();

            return listAllPast;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching your pasts rentals by id");
            throw;
        }
    }


    public async Task<List<RentalGetDto>> GetAllFuturesUserAsync(AppUser currentUser)
    {
        try
        {
            List<RentalGetDto> listAllFuture =
                await _context
                    .Rentals
                    .Where(r => r.CollaboratorId == currentUser.Collaborator.Id && r.StartDateId > DateTime.Now)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = currentUser.Collaborator.Id,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .ToListAsync();

            return listAllFuture;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching your futures rentals");
            throw;
        }
    }




    public async Task<RentalGetDto> GetByIdAsync(int id, AppUser currentUser)
    {
        try
        {
            RentalGetDto rental =
                await _context
                    .Rentals
                    .Where(r => r.CollaboratorId == currentUser.Collaborator.Id)
                    .Select(r => new RentalGetDto
                    {
                        Id = r.Id,
                        DriverId = r.CollaboratorId,
                        ModelName = r.Vehicle.Model.Name,
                        BrandName = r.Vehicle.Model.Brand.Name,
                        Registration = r.Vehicle.Registration,
                        StartDate = r.StartDateId,
                        EndDate = r.EndDateId,
                    })
                    .FirstOrDefaultAsync(r => r.Id == id) ??
                        throw new KeyNotFoundException($"No rental found for provided id {id}");

            return rental;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the rental by id");
            throw;
        }
    }


    public async Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto, AppUser currentUser)
    {
        try
        {
            List<VehicleRentalDto> listVehicleRentalDto =
                await vehicleRepository.GetAllByDatesAsync(new VehicleByDateDto
                {
                    StartDateId = rentalAddDto.StartDateId,
                    EndDateId = rentalAddDto.EndDateId,
                });

            if (listVehicleRentalDto.FirstOrDefault(v => v.Id == rentalAddDto.VehicleId) == null)
                throw new KeyNotFoundException($"No vehicle found for provided id {rentalAddDto.VehicleId}");

            DateDto rentalPeriod = await dateRepository.AddPeriodAsync(new DateDto
            {
                StartDate = rentalAddDto.StartDateId,
                EndDate = rentalAddDto.EndDateId,
            });

            await _context
                    .Rentals
                    .AddAsync(new Rental
                    {
                        VehicleId = rentalAddDto.VehicleId,
                        CollaboratorId = currentUser.Collaborator.Id,
                        StartDateId = rentalPeriod.StartDate,
                        EndDateId = rentalPeriod.EndDate,
                    });

            await _context.SaveChangesAsync();
            return rentalAddDto;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the rental by id");
            throw;
        }
    }


    public async Task<RentalUpdateDto> UpdateAsync(RentalUpdateDto rentalUpdateDto, AppUser currentUser)
    {
        try
        {
            Carpool? checkCarpool = await _context
                                        .Carpools
                                        .FirstOrDefaultAsync(c => c.RentalId == rentalUpdateDto.Id);

            if (checkCarpool == null ||
                !(rentalUpdateDto.StartDateId > checkCarpool.DateId ||
                rentalUpdateDto.EndDateId < checkCarpool.DateId))
            {

                Rental rentalToUpdate = await _context
                                            .Rentals
                                            .Where(r => r.CollaboratorId == currentUser.Collaborator.Id)
                                            .FirstOrDefaultAsync(r => r.Id == rentalUpdateDto.Id) ??
                                                throw new KeyNotFoundException($"No rental found for provided id {rentalUpdateDto.Id}");

                rentalToUpdate.VehicleId = rentalUpdateDto.VehicleId;
                rentalToUpdate.CollaboratorId = currentUser.Collaborator.Id;
                rentalToUpdate.StartDateId = rentalUpdateDto.StartDateId;
                rentalToUpdate.EndDateId = rentalUpdateDto.EndDateId;

                await _context.SaveChangesAsync();
                return rentalUpdateDto;
            }
            else
            {
                throw new Exception($"Sorry, you can't update your rental's dates. You already have a Carpool that starts on {checkCarpool.DateId.ToLongDateString()}");
            }
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the rental by id");
            throw;
        }
    }


    public async Task DeleteAsync(int id, AppUser currentUser)
    {
        try
        {
            Rental rentalToDelete =
                await _context
                    .Rentals
                    .Where(r => r.CollaboratorId == currentUser.Collaborator.Id)
                    .FirstOrDefaultAsync(r => r.Id == id) ??
                    throw new KeyNotFoundException($"No rental found for provided id {id}");

            _context.Rentals.Remove(rentalToDelete);
            await _context.SaveChangesAsync();

        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching the rental by id");
            throw;
        }
    }
}