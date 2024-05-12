using Services.DTOs.MotorDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Microsoft.Extensions.Logging;

namespace Repositories;

public class MotorRepository(DriveWiseContext _context, ILogger<MotorRepository> logger) : IMotorRepository
{
    public async Task<List<MotorGetDto>> GetAllAsync()
    {
        try
        {
            List<MotorGetDto> listAllMotors =
                await _context
                        .Motors
                        .Select(m => new MotorGetDto
                        {
                            Id = m.Id,
                            Type = m.Type,
                        })
                        .ToListAsync();

            return listAllMotors;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all motors");
            throw;
        }
    }


    public async Task<MotorGetDto> GetByIdAsync(int id)
    {
        try
        {
            MotorGetDto currentMotor =
                await _context
                        .Motors
                        .Select(m => new MotorGetDto
                        {
                            Id = m.Id,
                            Type = m.Type,
                        })
                        .FirstOrDefaultAsync(m => m.Id == id) ??
                            throw new KeyNotFoundException($"No motor found for the provided Id {id}");

            return currentMotor;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching motor by Id");
            throw;
        }
    }


    public async Task<MotorAddDto> AddAsync(MotorAddDto motorAddDto)
    {
        try
        {
            await _context
                    .Motors
                    .AddAsync(new Motor
                    {
                        Type = motorAddDto.Type,
                    });

            await _context.SaveChangesAsync();
            return motorAddDto;
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The motor type {motorAddDto.Type} is unique and already exist in database");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while adding the motor type");
            throw;
        }
    }


    public async Task<MotorUpdateDto> UpdateAsync(MotorUpdateDto motorUpdateDto)
    {
        try
        {
            Motor motorToUpdate =
                await _context
                        .Motors
                        .FirstOrDefaultAsync(m => m.Id == motorUpdateDto.Id) ??
                            throw new KeyNotFoundException($"No motor found for the provided Id {motorUpdateDto.Id}");

            motorToUpdate.Type = motorUpdateDto.Type;

            await _context.SaveChangesAsync();
            return motorUpdateDto;
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e.Message);
            throw;
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The motor type {motorUpdateDto.Type} is unique and already exist in database");
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating the motor type");
            throw;
        }
    }


    public async Task DeleteAsync(int id)
    {
        try
        {
            Motor motorToDelete =
                await _context
                        .Motors
                        .FirstOrDefaultAsync(m => m.Id == id) ??
                            throw new KeyNotFoundException($"No motor found for the provided Id {id}");

            _context.Motors.Remove(motorToDelete);
            await _context.SaveChangesAsync();

        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e.Message);
            throw;
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the motor type");
            throw;
        }
    }
}