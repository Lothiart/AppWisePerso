using Services.DTOs.AddressDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using Services.DTOs.AddressDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories;
public class AddressRepository(DriveWiseContext context, ILogger<AddressRepository> logger) : IAddressRepository
{
    public async Task AddAsync(AddressAddDto addressAddDto)
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
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, "Failed to add address to database");
            throw;
        }
    }

    public async Task DeleteByIdAsync(int id)
    {
        Address a = context.Addresses.Find(id) ?? throw new Exception("Address not found");

        context.Addresses.Remove(a);
        await context.SaveChangesAsync();
    }

    public async Task<AddressGetDto> GetByIdAsync(int id)
    {
        Address a = await context.Addresses.Include(a => a.City).FirstOrDefaultAsync(a => a.Id == id) ?? throw new Exception("Address not found");

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

    public async Task Update(AddressUpdateDto addressUpdateDto)
    {
        Address a = await context.Addresses.FirstOrDefaultAsync(a => a.Id == addressUpdateDto.Id) ?? throw new Exception("Address not found");

        a.Line1 = addressUpdateDto.Line1;
        a.Line2 = addressUpdateDto.Line2;
        a.CityId = addressUpdateDto.CityId;

        await context.SaveChangesAsync();

    }
}
