using DTOs;
using DTOs.AddressDTOs;
using DTOs.CollaboratorDTOs;
using DTOs.DTOs.CarpoolDTOs;
using DTOs.Mappers;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repositories;
public class CarpoolRepository(
    DriveWiseContext context,
    ILogger logger,
    ICollaboratorRepository collaboratorRepository,
    IVehicleRepository vehicleRepository,
    CarpoolMapper carpoolMapper
    ) : ICarpoolRepository
{
    public async Task AddAsync(CarpoolAddDto carpoolAddDto)
    {
        try
        {
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

    public async Task DeleteAsync(int id)
    {
        try
        {
            Carpool c = await context.Carpools.FindAsync(id) ?? throw new Exception("Carpool not found");

            context.Remove(c);
            await context.SaveChangesAsync();
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
                .Include(c => c.Vehicle)
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
    public async Task<List<CarpoolGetDto>> GetByCitiesAndDateAsync(string startCity, string endCity, DateTime dateId)
    {
        try
        {
            List<Carpool> carpools = await context.Carpools
                    .Include(c => c.StartAddress)
                    .Include(c => c.EndAddress)
                    .Include(c => c.Vehicle)
                    .Include(c => c.Driver)
                    .Include(c => c.Passengers)
                    .Where(c => c.StartAddress.City.Name == startCity && c.EndAddress.City.Name == endCity && c.DateId == dateId)
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
        throw new NotImplementedException();
    }

    public async Task<List<CarpoolGetDto>> GetByUserAndDateAscAsync()
    {
        throw new NotImplementedException();
    }

    public async Task Update(CarpoolUpdateDto carpoolUpdateDto)
    {
        throw new NotImplementedException();
    }
}
