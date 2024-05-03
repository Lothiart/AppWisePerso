using Entities;
using Services.DTOs.DateDTOs;

namespace Repositories.Contracts;

public interface IDateRepository
{
    Task<DateDto> AddPeriodAsync(DateDto dateDto);
    Task<DateDto> GetByPeriodAsync(DateDto dateDto);
    Task<DateDto> UpdateDateDtoAsync(DateDto dateDto);
    Task<DateDto> DeleteDtoAsync(DateDto dateDto);


    Task<DateTime?> GetByDateAsync(DateTime dateTime);
    Task<DateTime> AddAsync(DateTime dateTime);
    Task<DateTime> UpdateAsync(DateTime dateTime);
    Task<DateTime> DeleteAsync(DateTime dateTime);

}
