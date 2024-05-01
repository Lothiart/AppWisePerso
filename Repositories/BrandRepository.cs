using Services.DTOs.BrandDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;

namespace Repositories;
public class BrandRepository(DriveWiseContext context, ILogger<BrandRepository> logger) : IBrandRepository
{
    public async Task<BrandAddDto> AddAsync(BrandAddDto brandDto)
    {
        try
        {
            Brand b = new Brand() { Name = brandDto.Name };

            await context.AddAsync(b);
            await context.SaveChangesAsync();

            return brandDto;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to add brand to database");
            throw;
        }
    }

    /// <summary>
    /// Delete a brand.
    /// Returns number of deleted data in database
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            Brand? b = await context.Brands.FindAsync(id);

            if (b == null) return false;

            context.Brands.Remove(b);
            int numDeleted = await context.SaveChangesAsync();

            return numDeleted == 1 ? true : false;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to delete brand");
            throw;
        }
    }

    public async Task<List<BrandGetDto>> GetAllAsync()
    {
        try
        {
            List<Brand> brands = await context.Brands.ToListAsync();

            List<BrandGetDto> brandDtos = new();

            foreach (Brand brand in brands)
            {
                BrandGetDto dto = new BrandGetDto()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                };

                brandDtos.Add(dto);
            }

            return brandDtos;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get brands");
            throw;
        }
    }

    public async Task<BrandGetDto> GetByIdAsync(int id)
    {
        try
        {
            Brand? b = await context.Brands.FirstOrDefaultAsync(b => b.Id == id);

            if (b == null) return null;

            BrandGetDto brandDto = new BrandGetDto() { Id = b.Id, Name = b.Name };

            return brandDto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Brand> UpdateAsync(BrandUpdateDto brandDto)
    {
        try
        {
            Brand? b = await context.Brands.FindAsync(brandDto.Id);

            if (b == null) return null;

            b.Name = brandDto.Name;

            await context.SaveChangesAsync();

            return b;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
