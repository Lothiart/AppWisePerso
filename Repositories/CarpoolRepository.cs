using Services.DTOs.CarpoolDTOs;
using DTOs.Mappers;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System.Collections.Generic;

namespace Repositories;
public class CarpoolRepository(
    DriveWiseContext context,
    ILogger<CarpoolRepository> logger,
    CarpoolMapper carpoolMapper
    ) : ICarpoolRepository
{
    public async Task AddAsync(CarpoolAddDto carpoolAddDto)
    {
        try
        {
            if (carpoolAddDto.DateId >= carpoolAddDto.RentalGetDto.StartDate && carpoolAddDto.DateId <= carpoolAddDto.RentalGetDto.EndDate)
                throw new Exception("Date must be within your rental dates");

            Carpool c = carpoolMapper.CarpoolAddDtoToCarpool(carpoolAddDto);

            await context.Carpools.AddAsync(c);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to add carpool");
            throw;
        }
    }

    public async Task AddPassengerAsync(int carpoolId, int collaboratorId)
    {
        try
        {
            Carpool carpool = await context.Carpools.FindAsync(carpoolId) ?? throw new Exception("Carpool not found");
            Collaborator collaborator = await context.Collaborators.FindAsync(collaboratorId) ?? throw new Exception("Collaborator not found");

            carpool.Passengers.Add(collaborator);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to add passenger to carpool");
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Carpool c = await context.Carpools.FindAsync(id) ?? throw new Exception("Carpool not found");

            context.Remove(c);
            int modifiedLines = await context.SaveChangesAsync();

            return modifiedLines == 1 ? true : false;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to delete carpool");
            throw;
        }
    }

    public async Task<List<CarpoolGetDto>> GetAllAsync()
    {
        try
        {
            List<Carpool> carpools = await context.Carpools
                .Include(c => c.StartAddress)
                .Include(c => c.EndAddress)
                .Include(c => c.Rental)
                .Include(c => c.Driver)
                .Include(c => c.Passengers)
                .ToListAsync();

            return carpoolMapper.ListCarpoolToListCarpoolGetDto(carpools);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get carpools");
            throw;
        };
    }

    /// <summary>
    /// Find carpool (mapped in a DTO) that goes from startCity to endCity on dateId
    /// </summary>
    /// <param name="startCity"></param>
    /// <param name="endCity"></param>
    /// <param name="dateId"></param>
    /// <returns></returns>
    public async Task<List<CarpoolGetDto>> GetByCitiesAndDateAsync(CarpoolSearchDto carpoolSearch)
    {
        try
        {
            List<Carpool> carpools = await context.Carpools
                    .Include(c => c.StartAddress)
                    .Include(c => c.EndAddress)
                    .Include(c => c.Rental)
                    .Include(c => c.Driver)
                    .Include(c => c.Passengers)
                    .Where(c => c.StartAddress.City.Name == carpoolSearch.StartCity 
                                    && c.EndAddress.City.Name == carpoolSearch.EndCity 
                                    && c.DateId == carpoolSearch.DateId)
                    .ToListAsync();

            List<CarpoolGetDto> carpoolDtos = carpoolMapper.ListCarpoolToListCarpoolGetDto(carpools);

            return carpoolDtos;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get carpools");
            throw;
        }
    }

    public async Task<CarpoolGetDto> GetByIdAsync(int id)
    {
        try
        {
            Carpool c = await context.Carpools
                    .Include(c => c.StartAddress)
                    .Include(c => c.EndAddress)
                    .Include(c => c.Rental)
                    .Include(c => c.Driver)
                    .Include(c => c.Passengers)
                    .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception("Carpool not found)");

            return carpoolMapper.CarpoolToCarpoolGetDto(c);
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get carpool");
            throw;
        }
    }

    public async Task<List<CarpoolGetDto>> GetByUserAndDateAscAsync(int userId)
    {
        try
        {
            List<Carpool> carpools = await context.Carpools
                    .Include(c => c.StartAddress)
                    .Include(c => c.EndAddress)
                    .Include(c => c.Rental)
                    .Include(c => c.Driver)
                    .Include(c => c.Passengers)
                    .Where(c => c.DriverId == collaboratorId)
                    .OrderBy(c => c.DateId)
                    .ToListAsync();

            List<CarpoolGetDto> carpoolDtos = carpoolMapper.ListCarpoolToListCarpoolGetDto(carpools);

            return carpoolDtos;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get carpools");
            throw;
        }
    }

    public async Task<bool> UpdateAsync(CarpoolUpdateDto carpoolUpdateDto)
    {
        try
        {
            if (carpoolUpdateDto.DateId >= carpoolUpdateDto.RentalGetDto.StartDate && carpoolUpdateDto.DateId <= carpoolUpdateDto.RentalGetDto.EndDate)
                throw new Exception("Date must be within your rental dates");

            Carpool c = await context.Carpools.FindAsync(carpoolUpdateDto.Id) ?? throw new Exception("Carpool not found");

            if (carpoolUpdateDto.PassengersGetDto.Count <= 0)
            {
                c.DateId = carpoolUpdateDto.DateId;
                c.StartAddressId = carpoolUpdateDto.StartAddressDto.Id;
                c.EndAddressId = carpoolUpdateDto.EndAddress.Id;
                c.RentalId = carpoolUpdateDto.RentalGetDto.Id;

                int modifiedLines = await context.SaveChangesAsync();

                return modifiedLines == 1 ? true : false;
            }

            else throw new Exception("Cannot update carpool : carpool has passengers.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to update carpool");
            throw;
        }
    }
}
