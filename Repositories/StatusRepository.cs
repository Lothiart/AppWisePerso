using Services.DTOs.StatusDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class StatusRepository(DriveWiseContext _context) : IStatusRepository
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
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<StatusGetDto> GetByIdAsync(int id)
    {
        try
        {
            StatusGetDto? currentStatus =
                await _context
                    .Statuses
                    .Select(s => new StatusGetDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                    })
                    .FirstOrDefaultAsync(s => s.Id == id);

            return currentStatus;
        }
        catch (Exception)
        {
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
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Status> UpdateAsync(StatusUpdateDto statusUpdateDto)
    {
        try
        {
            Status? statusToUpdate =
                await _context
                    .Statuses
                    .FirstOrDefaultAsync(s => s.Id == statusUpdateDto.Id);

            if (statusToUpdate == null)
                return null;

            statusToUpdate.Name = statusUpdateDto.Name;

            await _context.SaveChangesAsync();
            return statusToUpdate;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Status> DeleteAsync(int id)
    {
        try
        {
            Status? statusToDelete =
                await _context
                    .Statuses
                    .FirstOrDefaultAsync(s => s.Id == id);

            if (statusToDelete == null)
                return null;

            _context.Statuses.Remove(statusToDelete);
            await _context.SaveChangesAsync();
            return statusToDelete;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
