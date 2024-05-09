using Services.DTOs.RentalDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.DTOs.DateDTOs;
using Services.DTOs.VehicleDTOs;

namespace Repositories;

public class RentalRepository(DriveWiseContext _context, IDateRepository dateRepository, IVehicleRepository vehicleRepository) : IRentalRepository
{

    public async Task<List<RentalGetDto>> GetAllCurrentAsync()
    {
        try
        {
            List<RentalGetDto> listAllCurrent =
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

            return listAllCurrent;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<RentalGetDto>> GetAllPastAsync()
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
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto)
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
                return null;


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
                        CollaboratorId = rentalAddDto.CollaboratorId,
                        StartDateId = rentalPeriod.StartDate,
                        EndDateId = rentalPeriod.EndDate,
                    });

            await _context.SaveChangesAsync();
            return rentalAddDto;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Rental> UpdateAsync(RentalUpdateDto rentalUpdateDto)
    {
        try
        {
            Carpool? checkCarpool = await _context
                                        .Carpools
                                        .FirstOrDefaultAsync(c => c.RentalId == rentalUpdateDto.Id);

            if (checkCarpool == null ||
                 checkCarpool.Passengers == null ||
                !(checkCarpool.Passengers.Count() != 0 &&
                (rentalUpdateDto.StartDateId > checkCarpool.DateId ||
                rentalUpdateDto.EndDateId < checkCarpool.DateId)))
            {

                Rental? rentalToUpdate = await _context
                                            .Rentals
                                            .FirstOrDefaultAsync(r => r.Id == rentalUpdateDto.Id);

                if (rentalToUpdate == null)
                    return null;

                rentalToUpdate.VehicleId = rentalUpdateDto.VehicleId;
                rentalToUpdate.CollaboratorId = rentalUpdateDto.CollaboratorId;
                rentalToUpdate.StartDateId = rentalUpdateDto.StartDateId;
                rentalToUpdate.EndDateId = rentalUpdateDto.EndDateId;

                await _context.SaveChangesAsync();
                return rentalToUpdate;
            }
            else
            {
                throw new Exception($"Sorry, you can't update your rental's dates. You already have a Carpool with {checkCarpool.Passengers.Count()} passenger(s) that starts on {checkCarpool.DateId.ToLongDateString()}");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Rental> DeleteAsync(int id)
    {
        try
        {
            Rental? rentalToDelete = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == id);

            if (rentalToDelete == null)
                return null;

            _context.Rentals.Remove(rentalToDelete);
            await _context.SaveChangesAsync();
            return rentalToDelete;
        }
        catch (Exception)
        {
            throw;
        }
    }
}