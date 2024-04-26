using DTOs.DTOs.BrandDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class BrandRepository(DriveWiseContext context, ILogger<BrandRepository> logger) : IBrandRepository
{
    public async Task AddAsync(BrandAddDto brandDto)
    {
        try
        {
            Brand b = new Brand() { Name = brandDto.Name };
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to add brand to database");
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        Brand b = await context.Brands.FindAsync(id) ?? throw new Exception("Brand not found");

        context.Remove(b);
        await context.SaveChangesAsync();
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

    public async Task<BrandGetDto> GetById(int id)
    {
        Brand b = await context.Brands.FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception("Brand not found");

        BrandGetDto brandDto = new BrandGetDto() { Id = b.Id, Name = b.Name };

        return brandDto;
    }

    public async Task UpdateAsync(BrandUpdateDto brandUpdateDto)
    {
        Brand b = await context.Brands.FindAsync(brandUpdateDto.Id) ?? throw new Exception("Brand not found");

        b.Name = brandUpdateDto.Name;

        await context.SaveChangesAsync();
    }
}
