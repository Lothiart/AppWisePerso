using Services.DTOs.CityDTOs;
using Entities.Contexts;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;


namespace Repositories;

public class CityRepository(DriveWiseContext driveWiseContext, ILogger<CityRepository> logger) : ICityRepository
{
    public async Task AddAsync(CityAddDto cityAddDto)
    {
        try
        {
            await driveWiseContext.Cities.AddAsync(new City() { Name = cityAddDto.Name, ZipCode = cityAddDto.ZipCode });
            await driveWiseContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e!.InnerException!.Message);
            throw;
        }

    }

    public async Task<CityGetDto> GetByIdAsync(int id)
    {
        try
        {
            City city = await driveWiseContext.Cities.FirstOrDefaultAsync(c => c.Id == id);
            return new CityGetDto() { Id = city.Id, Name = city.Name, ZipCode = city.ZipCode };
        }
        catch (Exception e)
        {
            logger.LogError(e!.InnerException!.Message);
            throw;
        }

    }
    public async Task<List<CityGetDto>> GetAllAsync()
    {
        try
        {
            List<CityGetDto> listAllCity =
                await driveWiseContext
                        .Cities
                        .Select(m => new CityGetDto
                        {
                            Id = m.Id,
                            Name = m.Name,
                            ZipCode = m.ZipCode
                        })
                        .ToListAsync();

            return listAllCity;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<CityGetDto>> StartsWithAsync(string recherche)
    {
        try
        {
            List<City> cities = await driveWiseContext.Cities.Where(c => c.Name.Contains(recherche)).ToListAsync();
            List<CityGetDto> citiesDto = new List<CityGetDto>();
            foreach (City city in cities)
            {
                citiesDto.Add(new CityGetDto() { Id = city.Id, Name = city.Name, ZipCode = city.ZipCode });
            }
            return citiesDto;
        }
        catch (Exception e)
        {
            logger.LogError(e!.InnerException!.Message);
            throw;
        }
    }

    public async Task UpdateAsync(CityUpdateDto cityUpdateDto)
    {
        try
        {
            City city = await driveWiseContext.Cities.FirstOrDefaultAsync(c => c.Id == cityUpdateDto.Id);
            city.Name = cityUpdateDto.Name;
            city.ZipCode = cityUpdateDto.ZipCode;
            driveWiseContext.Cities.Update(city);
            await driveWiseContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e!.InnerException!.Message);
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            City city = await driveWiseContext.Cities.FirstOrDefaultAsync(c => c.Id == id);
            driveWiseContext.Cities.Remove(city);
            await driveWiseContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e!.InnerException!.Message);
            throw;
        }
    }
}