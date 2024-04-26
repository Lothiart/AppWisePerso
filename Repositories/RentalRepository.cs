using DTOs.DTOs.RentalDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;


// VERIFICATION DES DATES A FAIRE POUR ADD ET L'UPDATE 


public class RentalRepository(DriveWiseContext _context) : IRentalRepository
{
    public async Task<List<RentalGetDto>> GetAllAsync()
    {
        List<Rental> AllRentals = await _context
                                            .Rentals
                                            .ToListAsync();

        if (AllRentals == null)
            return null;

        List<RentalGetDto> listRentalsDto = new List<RentalGetDto>();

        foreach (Rental rental in AllRentals)
        {
            RentalGetDto allRentalsDto = new RentalGetDto
            {
                Id = rental.Id,
                VehiculeId = rental.VehiculeId,
                CollaboratorId = rental.CollaboratorId,
                StartDateId = rental.StartDateId,
                EndDateId = rental.EndDateId,
            };
            listRentalsDto.Add(allRentalsDto);
        }
        return listRentalsDto;
    }
    public async Task<RentalGetDto> GetByIdAsync(int id)
    {
        Rental currenRental = await _context
                                        .Rentals
                                        .FirstOrDefaultAsync(m => m.Id == id);

        if (currenRental == null)
            return null;

        RentalGetDto oneRentalDto = new RentalGetDto
        {
            Id = currenRental.Id,
            VehiculeId = currenRental.VehiculeId,
            CollaboratorId = currenRental.CollaboratorId,
            StartDateId = currenRental.StartDateId,
            EndDateId = currenRental.EndDateId,
        };
        return oneRentalDto;
    }
    public async Task<List<RentalGetDto>> GetAllByUserAsync(int id)
    {
        List<Rental> AllRentalsByUser = await _context
                                        .Rentals
                                        .Where(r => r.Collaborator.Id == id)
                                        .ToListAsync();

        if (AllRentalsByUser == null)
            return null;

        List<RentalGetDto> listRentalsDto = new List<RentalGetDto>();

        foreach (Rental rental in AllRentalsByUser)
        {
            RentalGetDto AllRentalsByUserDto = new RentalGetDto
            {
                Id = rental.Id,
                VehiculeId = rental.VehiculeId,
                CollaboratorId = rental.CollaboratorId, // inutile
                StartDateId = rental.StartDateId,
                EndDateId = rental.EndDateId,
            };
            listRentalsDto.Add(AllRentalsByUserDto);
        }
        return listRentalsDto;

    }
    public async Task<RentalAddDto> AddAsync(RentalAddDto rentalAddDto)
    {
        try
        {
            await _context.Rentals.AddAsync(new Rental
            {
                VehiculeId = rentalAddDto.VehiculeId,
                CollaboratorId = rentalAddDto.CollaboratorId,
                StartDateId = rentalAddDto.StartDateId,
                EndDateId = rentalAddDto.EndDateId,
            });

            await _context.SaveChangesAsync();
            return rentalAddDto;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<RentalUpdateDto> UpdateAsync(RentalUpdateDto rentalUpdateDto)
    {
        Rental rentalToUpdate = await _context
                                            .Rentals
                                            .FirstOrDefaultAsync(r => r.Id == rentalUpdateDto.Id);

        if (rentalToUpdate == null)
            return null;

        rentalToUpdate.VehiculeId = rentalUpdateDto.VehiculeId;
        rentalToUpdate.CollaboratorId = rentalUpdateDto.CollaboratorId;
        rentalToUpdate.StartDateId = rentalUpdateDto.StartDateId;
        rentalToUpdate.EndDateId = rentalUpdateDto.EndDateId;


        try
        {
            await _context.SaveChangesAsync();
            return new RentalUpdateDto
            {
                VehiculeId = rentalUpdateDto.VehiculeId,
                CollaboratorId = rentalUpdateDto.CollaboratorId,
                StartDateId = rentalUpdateDto.StartDateId,
                EndDateId = rentalUpdateDto.EndDateId,
            };
        }
        catch (Exception)
        {

            throw;
        }

    }
    public async Task<Rental> DeleteAsync(int id)
    {
        Rental rentalToDelete = await _context.Rentals.FindAsync(id);

        if (rentalToDelete == null)
            return null;

        try
        {
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
