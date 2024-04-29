using Services.DTOs.MotorDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class MotorRepository(DriveWiseContext _context) : IMotorRepository
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
        catch (Exception)
        {

            throw;
        }
    }


    public async Task<MotorGetDto> GetByIdAsync(int id)
    {
        try
        {
            MotorGetDto? currentMotor =
                await _context
                        .Motors
                        .Select(m => new MotorGetDto
                        {
                            Id = m.Id,
                            Type = m.Type,
                        })
                        .FirstOrDefaultAsync(m => m.Id == id);

            return currentMotor;
        }
        catch (Exception)
        {

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
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Motor> UpdateAsync(MotorUpdateDto motorUpdateDto)
    {
        try
        {
            Motor? motorToUpdate =
                await _context
                        .Motors
                        .FirstOrDefaultAsync(m => m.Id == motorUpdateDto.Id);

            if (motorToUpdate == null)
                return null;

            motorToUpdate.Id = motorUpdateDto.Id;
            motorToUpdate.Type = motorUpdateDto.Type;

            await _context.SaveChangesAsync();
            return motorToUpdate;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<Motor> DeleteAsync(int id)
    {
        try
        {
            Motor? motorToDelete =
                await _context
                        .Motors
                        .FirstOrDefaultAsync(m => m.Id == id);

            if (motorToDelete == null)
                return null;

            _context.Motors.Remove(motorToDelete);
            await _context.SaveChangesAsync();
            return motorToDelete;
        }
        catch (Exception)
        {
            throw;
        }
    }
}