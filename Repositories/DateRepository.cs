using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.DTOs.DateDTOs;


namespace Repositories;

public class DateRepository(DriveWiseContext _context) : IDateRepository
{

    public async Task<DateDto> AddPeriodAsync(DateDto dateDto)
    {
        try
        {

            List<Date> newPeriod = new List<Date>
            {
                new Date {Id = dateDto.StartDate},
                new Date {Id = dateDto.EndDate}
            };

            await _context
                .Dates
                .AddRangeAsync(newPeriod);

            await _context.SaveChangesAsync();
            return dateDto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<DateDto> GetByPeriodAsync(DateDto dateDto)
    {
        try
        {
            Date? currentStartDate =
                await _context
                    .Dates
                    .FirstOrDefaultAsync(d => d.Id == dateDto.StartDate);

            Date? currentEndDate =
                await _context
                    .Dates
                    .FirstOrDefaultAsync(d => d.Id == dateDto.EndDate);

            if (currentStartDate == null || currentEndDate == null)
                return null;

            DateDto currentPeriod = new DateDto
            {
                StartDate = currentStartDate.Id,
                EndDate = currentEndDate.Id,
            };

            return currentPeriod;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<DateTime> AddAsync(DateTime dateTime)
    {
        try
        {
            await _context
            .Dates
            .AddAsync(new Date
            {
                Id = dateTime
            });

            await _context.SaveChangesAsync();
            return dateTime;
        }
        catch (Exception)
        {
            throw;
        }
    }



    public async Task<DateTime?> GetByDateAsync(DateTime dateTime)
    {
        try
        {
            DateTime? currentDateTime =
                await _context
                    .Dates
                    .Select(d => new DateTime())
                    // {
                    //     Id = d.Id,
                    // })
                    .FirstOrDefaultAsync(d => d == dateTime);


            return currentDateTime;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public Task<DateDto> DeleteDtoAsync(DateDto dateDto)
    {
        throw new NotImplementedException();
    }

    public Task<DateDto> UpdateDateDtoAsync(DateDto dateDto)
    {
        throw new NotImplementedException();
    }

    public Task<DateTime> UpdateAsync(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public Task<DateTime> DeleteAsync(DateTime dateTime)
    {
        throw new NotImplementedException();
    }

}
