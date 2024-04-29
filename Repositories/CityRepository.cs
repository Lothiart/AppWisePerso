using Services.DTOs.CityDTOs;
using Entities.Contexts;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CityRepository : ICityRepository
    {

        DriveWiseContext driveWiseContext;
        ILogger<CityRepository> logger;

        public CityRepository(DriveWiseContext driveWiseContext, ILogger<CityRepository> logger)
        {
            this.driveWiseContext = driveWiseContext;
            this.logger = logger;
        }
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

        public async Task<List<CityGetDto>> StartsWithAsync(string recherche)
        {
            try
            {
                List<City> cities = await driveWiseContext.Cities.Where(c => c.Name == $"{recherche}%").ToListAsync();
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
}
