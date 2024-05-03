using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Mocks;
using Repositories;
using Services.DTOs.AddressDTOs;

namespace RepositoriesTests;

[TestClass]
public class AddressRepositoryTest
{
    private const string DATABASE_PATH = "DriveWiseDatabase.sqlite";

    #region GetByIdAsync
    [TestMethod]
    public async Task GetByIdAsync_AddressToFind_AddressFound()
    {
        //Arrange
        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={DATABASE_PATH}");

        MockLogger<AddressRepository> logger = new MockLogger<AddressRepository>();

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            AddressRepository addressRepository = new AddressRepository(context, logger);

            City newCity = new City() { Id = 1, ZipCode = 34000, Name = "Montpellier" };
            Address address = new Address { Id = 1, Line1 = "test", Line2 = "test", CityId = 1 };

            await context.Cities.AddAsync(newCity);
            await context.SaveChangesAsync();

            await context.Addresses.AddAsync(address);
            await context.SaveChangesAsync();

            //Act
            AddressGetDto result = await addressRepository.GetByIdAsync(1);
            Address addressFromDto = new Address
            {
                Id = result.Id,
                Line1 = result.Line1,
                Line2 = result.Line2,
                CityId = result.CityId
            };

            //Assert
            Assert.AreEqual(address.Id, addressFromDto.Id);
            Assert.AreEqual(address.Line1, addressFromDto.Line1);
            Assert.AreEqual(address.Line2, addressFromDto.Line2);
            Assert.AreEqual(address.CityId, addressFromDto.CityId);
        }
    }

    [TestMethod]
    public async Task GetByIdAsync_InvalidAddressToFind_Null()
    {
        //Arrange
        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={DATABASE_PATH}");

        MockLogger<AddressRepository> logger = new MockLogger<AddressRepository>();

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            AddressRepository addressRepository = new AddressRepository(context, logger);

            //Act
            AddressGetDto result = await addressRepository.GetByIdAsync(1);

            //Assert
            Assert.IsNull(result);
        }
    }
    #endregion

    #region CreateAsync
    [TestMethod]
    public async Task CreateAsync_AddressToCreate_AddressAdded()
    {
        //Arrange
        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={DATABASE_PATH}");

        MockLogger<AddressRepository> mockLogger = new MockLogger<AddressRepository>();

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
        }
    }
    #endregion
}
