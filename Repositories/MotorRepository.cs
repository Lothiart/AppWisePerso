using DTOs.DTOs.MotorDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories;

public class MotorRepository(DriveWiseContext _context) : IMotorRepository
{
    public async Task<List<MotorGetDto>> GetAllAsync()
    {
        List<Motor> AllMotors = await _context.Motors.ToListAsync();

        if (AllMotors == null)
            return null;

        List<MotorGetDto> ListMotorsDto = new List<MotorGetDto>();

        foreach (Motor motor in AllMotors)
        {
            MotorGetDto allMotorsDto = new MotorGetDto
            {
                Id = motor.Id,
                Type = motor.Type,
            };
            ListMotorsDto.Add(allMotorsDto);
        }
        return ListMotorsDto;
    }

    public async Task<MotorGetDto> GetByIdAsync(int id)
    {
        Motor currentMotor = await _context.Motors.FirstOrDefaultAsync(m => m.Id == id);

        if (currentMotor == null)
            return null;

        MotorGetDto OneMotorDto = new MotorGetDto
        {
            Id = currentMotor.Id,
            Type = currentMotor.Type,
        };
        return OneMotorDto;
    }

    public async Task<MotorAddDto> AddAsync(MotorAddDto motorAddDto)
    {
        try
        {
            await _context.Motors.AddAsync(new Motor
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

    public async Task<MotorUpdateDto> UpdateAsync(MotorUpdateDto motorUpdateDto)
    {
        Motor motorToUpdate = await _context.Motors.FirstOrDefaultAsync(m => m.Id == motorUpdateDto.Id);
        if (motorToUpdate == null)
            return null;

        motorToUpdate.Id = motorUpdateDto.Id;
        motorToUpdate.Type = motorUpdateDto.Type;

        try
        {
            await _context.SaveChangesAsync();
            return new MotorUpdateDto
            {
                Id = motorUpdateDto.Id,
                Type = motorUpdateDto.Type,
            };
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Motor> DeleteAsync(int id)
    {
        Motor motorToDelete = await _context.Motors.FirstOrDefaultAsync(m => m.Id == id);

        if (motorToDelete == null)
            return null;

        try
        {
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