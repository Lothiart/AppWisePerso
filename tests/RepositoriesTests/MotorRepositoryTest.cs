using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Mocks;
using Repositories;
using Services.DTOs.MotorDTOs;

namespace RepositoriesTests;

[TestClass]

public class MotorRepositoryTest
{
    private const string DATABASE_PATH = "DriveWiseDatabase.sqlite";

    private DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
                                                                    .UseSqlite($"DataSource={DATABASE_PATH}");

    [TestInitialize]

    public void Initialize()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();
        }
    }


    [TestMethod]

    public async Task GetAllAsyncTest_Empty_MotorGetDtoList()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            // Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            List<Motor> motors = new List<Motor>
            {
                new Motor
                {
                    Id = 1,
                    Type = "fuel"
                },
                new Motor
                {
                    Id = 2,
                    Type = "GasOil"
                }
            };

            await context.Motors.AddRangeAsync(motors);
            await context.SaveChangesAsync();

            // Act

            List<MotorGetDto> result = await motorRepository.GetAllAsync();

            // Assert

            Assert.AreEqual(motors.Count(), result.Count());
            Assert.AreEqual("fuel", result[0].Type);
            Assert.AreEqual("GasOil", result[1].Type);

        }
    }


    [TestMethod]

    public async Task GetByIdAsyncTest_Id_MotorGetDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Id = 1,
                Type = "fuel"
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            //Act 

            MotorGetDto result = await motorRepository.GetByIdAsync(1);

            // Assert

            Assert.AreEqual(motor.Type, result.Type);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task GetByIdAsyncTest_Id_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Id = 1,
                Type = "fuel"
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            //Act 

            await motorRepository.GetByIdAsync(2);

        }
    }


    [TestMethod]

    public async Task AddAsyncTest_MotorAddDto_MotorAddDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            MotorAddDto motorAddDto = new MotorAddDto
            {
                Type = "Test",
            };

            // Act

            MotorAddDto result = await motorRepository.AddAsync(motorAddDto);

            // Assert

            Assert.AreEqual("Test", result.Type);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(DbUpdateException))]

    public async Task AddAsyncTest_MotorAddDto_DbUpdateException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Type = "Test",
            };

            MotorAddDto motorAddDto = new MotorAddDto
            {
                Type = "Test",
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();


            // Act

            MotorAddDto result = await motorRepository.AddAsync(motorAddDto);

        }
    }


    [TestMethod]

    public async Task UpdateAsyncTest_MotorUpdateDto_MotorUpdateDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Type = "Test",
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            MotorUpdateDto motorUpdateDto = new MotorUpdateDto
            {
                Id = 1,
                Type = "Update",
            };

            // Act

            MotorUpdateDto result = await motorRepository.UpdateAsync(motorUpdateDto);

            // Assert

            Assert.AreEqual("Update", result.Type);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task UpdateAsyncTest_MotorUpdateDto_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Type = "Test",
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            MotorUpdateDto motorUpdateDto = new MotorUpdateDto
            {
                Id = 2,
                Type = "Update",
            };

            // Act

            await motorRepository.UpdateAsync(motorUpdateDto);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(DbUpdateException))]

    public async Task UpdateAsyncTest_MotorUpdateDto_DbUpdateException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            List<Motor> motorList = new List<Motor>
            {
                new Motor
                {
                    Type = "Test",
                },
                 new Motor
                {
                    Type = "Test2",
                }
            };

            await context.Motors.AddRangeAsync(motorList);
            await context.SaveChangesAsync();

            MotorUpdateDto motorUpdateDto = new MotorUpdateDto
            {
                Id = 2,
                Type = "Test",
            };

            // Act

            await motorRepository.UpdateAsync(motorUpdateDto);

        }
    }


    [TestMethod]

    public async Task DeleteAsyncTest_Int_Void()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Type = "Test",
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            // Act

            await motorRepository.DeleteAsync(1);

            // Assert

            Motor? result = await context.Motors.FirstOrDefaultAsync(m => m.Id == 1);

            Assert.IsNull(result);
        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task DeleteAsyncTest_Int_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<MotorRepository> logger = new MockLogger<MotorRepository>();

            MotorRepository motorRepository = new MotorRepository(context, logger);

            Motor motor = new Motor
            {
                Type = "Test",
            };

            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            // Act

            await motorRepository.DeleteAsync(2);

        }
    }
}