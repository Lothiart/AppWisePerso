using Services.DTOs.AddressDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;


namespace Repositories;
public class AddressRepository(DriveWiseContext context, ILogger<AddressRepository> logger) : IAddressRepository
{
    public async Task<AddressAddDto> AddAsync(AddressAddDto addressAddDto)
    {
        try
        {
            Address a = new Address()
            {
                Line1 = addressAddDto.Line1,
                Line2 = addressAddDto.Line2,
                CityId = addressAddDto.CityId,
            };

            await context.Addresses.AddAsync(a);
            await context.SaveChangesAsync();

            return addressAddDto;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to add address to database");
            throw;
        }
    }

    public async Task<Address> DeleteAsync(int id)
    {
        try
        {
            Address? a = await context.Addresses.FindAsync(id);

            if (a == null) return null;

            context.Addresses.Remove(a);
            await context.SaveChangesAsync();
            return a;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to delete address");
            throw;
        }
    }

    public async Task<AddressGetDto> GetByIdAsync(int id)
    {
        try
        {
            Address? a = await context.Addresses.Include(a => a.City).FirstOrDefaultAsync(a => a.Id == id);

            if (a == null) return null;

            AddressGetDto addressDto = new AddressGetDto()
            {
                Id = a.Id,
                Line1 = a.Line1,
                Line2 = a.Line2,
                CityId = a.CityId,
                City = a.City.Name
            };

            return addressDto;
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to get address");
            throw;
        }
    }

    public async Task<AddressUpdateDto> UpdateAsync(AddressUpdateDto addressUpdateDto)
    {
        try
        {
            Address? a = await context.Addresses.FirstOrDefaultAsync(a => a.Id == addressUpdateDto.Id);

            if (a == null) return null;

            a.Line1 = addressUpdateDto.Line1;
            a.Line2 = addressUpdateDto.Line2;
            a.CityId = addressUpdateDto.CityId;

            await context.SaveChangesAsync();
            return addressUpdateDto;

        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to update address");
            throw;
        }
    }
}
