using DTOs.DTOs.StatusDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class StatusRepository(DriveWiseContext _context) : IStatusRepository
{
    public async Task<List<StatusGetDto>> GetAllAsync()
    {
        List<Status> allStatuses = await _context.Statuses.ToListAsync();

        if (allStatuses == null)
            return null;

        List<StatusGetDto> listStatusesDto = new List<StatusGetDto>();
        foreach (Status status in allStatuses)
        {
            StatusGetDto allStatusesDto = new StatusGetDto
            {
                Id = status.Id,
                Name = status.Name,
            };
            listStatusesDto.Add(allStatusesDto);
        }
        return listStatusesDto;
    }

    public async Task<StatusGetDto> GetByIdAsync(int id)
    {
        Status currentStatus = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == id);

        if (currentStatus == null)
            return null;

        StatusGetDto oneStatusDto = new StatusGetDto
        {
            Id = currentStatus.Id,
            Name = currentStatus.Name,
        };
        return oneStatusDto;
    }


    public async Task<StatusAddDto> AddAsync(StatusAddDto statusAddDto)
    {
        try
        {
            await _context.Statuses.AddAsync(new Status
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

    public async Task<StatusUpdateDto> UpdateAsync(StatusUpdateDto statusUpdateDto)
    {
        Status statusToUpdate = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == statusUpdateDto.Id);

        if (statusToUpdate == null)
            return null;

        statusToUpdate.Name = statusUpdateDto.Name;

        try
        {
            await _context.SaveChangesAsync();
            return new StatusUpdateDto
            {
                Name = statusUpdateDto.Name,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Status> DeleteAsync(int id)
    {

        Status statusToDelete = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == id);

        if (statusToDelete == null)
            return null;

        try
        {
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
