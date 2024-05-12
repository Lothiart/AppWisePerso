using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Mocks;
using Repositories;
using Services.DTOs.StatusDTOs;

/* 

At database's initialisation,
status table is automatically fulfilled with 3 statuses:

[
    {Id = 1, Name = STATUS.AVAILABLE},
    {Id = 2, Name = STATUS.INREPAIR},
    {Id = 3, Name = STATUS.OUTOFSERVICE}
]

*/

namespace RepositoriesTests;

[TestClass]

public class StatusRepositoryTest
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

    public async Task GetAllAsyncTest_Empty_StatusGetDtoList()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            List<Status> statuses = new List<Status>
            {
                new Status
                {
                     Id = 1,
                     Name = STATUS.AVAILABLE
                },
                new Status
                {
                     Id = 2,
                      Name = STATUS.INREPAIR
                },
                new Status
                {
                     Id = 3,
                      Name = STATUS.OUTOFSERVICE
                }
            };

            //Act

            List<StatusGetDto> result = await statusRepository.GetAllAsync();

            //Assert

            Assert.AreEqual(statuses.Count, result.Count);
            Assert.AreEqual(statuses[0].Name, result[0].Name);
            Assert.AreEqual(statuses[1].Name, result[1].Name);
            Assert.AreEqual(statuses[2].Name, result[2].Name);
        }
    }


    [TestMethod]

    public async Task GetByIdAsyncTest_Id_StatusGetDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            Status status = new Status
            {
                Id = 1,
                Name = STATUS.AVAILABLE
            };

            //Act

            StatusGetDto result = await statusRepository.GetByIdAsync(1);

            //Assert

            Assert.AreEqual(status.Name, result.Name);
        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task GetByIdAsyncTest_Id_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            //Act

            await statusRepository.GetByIdAsync(4);

        }
    }


    [TestMethod]

    public async Task AddAsyncTest_StatusAddDto_StatusAddDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            StatusAddDto statusAddDto = new StatusAddDto
            {
                Name = "Test"
            };

            //Act

            StatusAddDto result = await statusRepository.AddAsync(statusAddDto);

            // Assert

            Assert.AreEqual("Test", result.Name);
        }
    }


    [TestMethod]

    public async Task UpdateAsyncTest_StatusUpdateDto_StatusUpdateDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            StatusUpdateDto statusUpdateDto = new StatusUpdateDto
            {
                Id = 1,
                Name = "Update",
            };

            //Act

            StatusUpdateDto result = await statusRepository.UpdateAsync(statusUpdateDto);

            // Assert

            Assert.AreEqual("Update", result.Name);
        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task UpdateAsyncTest_StatusUpdateDto_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            StatusUpdateDto statusUpdateDto = new StatusUpdateDto
            {
                Id = 4,
                Name = "Update",
            };

            //Act

            await statusRepository.UpdateAsync(statusUpdateDto);

        }
    }




    [TestMethod]

    public async Task DeleteAsyncTest_int_Void()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            //Act

            await statusRepository.DeleteAsync(1);

            // Assert

            Status? result = await context.Statuses.FirstOrDefaultAsync(s => s.Id == 1);

            Assert.IsNull(result);
        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task DeleteAsyncTest_int_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<StatusRepository> logger = new MockLogger<StatusRepository>();

            StatusRepository statusRepository = new StatusRepository(context, logger);

            //Act

            await statusRepository.DeleteAsync(4);

        }
    }
}