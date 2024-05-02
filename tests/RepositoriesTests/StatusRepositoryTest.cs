using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.DTOs.StatusDTOs;


namespace RepositoriesTests;

[TestClass]
public class StatusRepositoryTest
{
    private string databasePath;

    [TestMethod]
    public async Task GetAllAsyncTest_Empty_StatusList()
    {
        //Arrange
        databasePath = "DriveWiseDatabase.sqlite";


        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            List<Status> statuses = new List<Status>
            {
                new Status { Id = 1,Name = STATUS.AVAILABLE,},
                new Status { Id = 2, Name = STATUS.INREPAIR,},
                new Status { Id = 3, Name = STATUS.OUTOFSERVICE,}
            };

            //Act

            List<StatusGetDto> result = await statusRepository.GetAllAsync();

            //Assert

            Assert.AreEqual(statuses[0].Name, result[0].Name);
            Assert.AreEqual(statuses[1].Name, result[1].Name);
            Assert.AreEqual(statuses[2].Name, result[2].Name);
        }
    }

    [TestMethod]

    public async Task GetByIdAsyncTest_Id_OneStatus()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            Status status = new Status { Id = 1, Name = STATUS.AVAILABLE };

            //Act

            StatusGetDto result = await statusRepository.GetByIdAsync(1);

            //Assert

            Assert.AreEqual(status.Name, result.Name);
        }
    }


    [TestMethod]

    public async Task GetByIdAsyncTest_Id_Null()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            //Act

            StatusGetDto result = await statusRepository.GetByIdAsync(4);

            //Assert

            Assert.IsNull(result);
        }
    }


    [TestMethod]

    public async Task GetByIdAsyncTest_Id_NullBadRequest()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            //Act

            StatusGetDto result = await statusRepository.GetByIdAsync(-2);

            // Assert
            Assert.IsNull(result);
        }
    }

    [TestMethod]

    public async Task AddAsyncTest_StatusAddDto_StatusAddDto()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            Status newStatus = new Status
            {
                Name = "Test"
            };

            StatusAddDto statusAddDto = new StatusAddDto
            {
                Name = newStatus.Name,
            };

            await context.Statuses.AddAsync(newStatus);
            await context.SaveChangesAsync();

            //Act

            StatusAddDto result = await statusRepository.AddAsync(statusAddDto);

            // Assert
            Assert.AreEqual(newStatus.Name, result.Name);
        }
    }

    [TestMethod]

    public async Task UpdateAsyncTest_StatusAddDto_StatusAddDto()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);


            StatusUpdateDto statusUpdateDto = new StatusUpdateDto
            {
                Id = 1,
                Name = "Test",
            };


            //Act

            Status result = await statusRepository.UpdateAsync(statusUpdateDto);

            // Assert
            Assert.AreEqual(statusUpdateDto.Name, result.Name);
        }
    }


    [TestMethod]

    public async Task DeleteAsyncTest_int_Status()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite($"DataSource={databasePath}");


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);


            //Act

            await statusRepository.DeleteAsync(1);

            // Assert
            Status? deletedStatus = await context.Statuses.FirstOrDefaultAsync(s => s.Id == 1);
            Assert.IsNull(deletedStatus);
        }
    }
}