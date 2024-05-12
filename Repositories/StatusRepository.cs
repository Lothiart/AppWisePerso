using Services.DTOs.StatusDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace Repositories;

public class StatusRepository(DriveWiseContext _context, ILogger<StatusRepository> logger) : IStatusRepository
{
    public async Task<List<StatusGetDto>> GetAllAsync()
    {
        try
        {
            List<StatusGetDto> listAllStatuses =
                await _context
                        .Statuses
                        .Select(s => new StatusGetDto
                        {
                            Id = s.Id,
                            Name = s.Name,
                        })
                        .ToListAsync();

            return listAllStatuses;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all statuses");
            throw;
        }
    }


    public async Task<StatusGetDto> GetByIdAsync(int id)
    {
        try
        {
            StatusGetDto currentStatus =
                await _context
                    .Statuses
                    .Select(s => new StatusGetDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .FirstOrDefaultAsync(s => s.Id == id) ??
                        throw new KeyNotFoundException($"No status found for the provided Id {id}");

            return currentStatus;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching status by Id");
            throw;
        }
    }


    public async Task<StatusAddDto> AddAsync(StatusAddDto statusAddDto)
    {
        try
        {
            await _context
                .Statuses
                .AddAsync(new Status
                {
                    Name = statusAddDto.Name,
                });

            await _context.SaveChangesAsync();
            return statusAddDto;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while adding the status name");
            throw;
        }
    }


    public async Task<StatusUpdateDto> UpdateAsync(StatusUpdateDto statusUpdateDto)
    {
        try
        {
            Status statusToUpdate =
                await _context
                        .Statuses
                        .FirstOrDefaultAsync(s => s.Id == statusUpdateDto.Id) ??
                            throw new KeyNotFoundException($"No status found for the provided Id {statusUpdateDto.Id}");

            statusToUpdate.Name = statusUpdateDto.Name;

            await _context.SaveChangesAsync();
            return statusUpdateDto;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating the status name");
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            Status statusToDelete =
                await _context
                    .Statuses
                    .FirstOrDefaultAsync(s => s.Id == id) ??
                            throw new KeyNotFoundException($"No status found for the provided Id {id}");

            _context.Statuses.Remove(statusToDelete);
            await _context.SaveChangesAsync();
        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the status name");
            throw;
        }
    }
}
