using System.Net;
using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.DTOs.StatusDTOs;


namespace RepositoriesTests;

[TestClass]
public class StatusRepositoryTest
{

    [TestMethod]
    public async Task GetAllAsyncTest_Empty_StatusList()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite("DataSource=:memory:");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            List<Status> statuses = new List<Status>
            {
                new Status { Id = 1,Name = "AVAILABLE",},
                new Status { Id = 2, Name = "INREPAIR",}
            };

            await context.Statuses.AddRangeAsync(statuses);
            await context.SaveChangesAsync();

            //Act

            List<StatusGetDto> result = await statusRepository.GetAllAsync();

            //Assert

            Assert.AreEqual(statuses.Count, result.Count);
        }
    }

    [TestMethod]

    public async Task GetAllAsyncTest_Empty_EmptyList()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite("DataSource=:memory:");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            //Act

            List<StatusGetDto> result = await statusRepository.GetAllAsync();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }

    [TestMethod]

    public async Task GetByIdAsyncTest_Id_OneStatus()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite("DataSource=:memory:");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            Status status = new Status { Id = 1, Name = "AVAILABLE", };

            await context.Statuses.AddAsync(status);
            await context.SaveChangesAsync();

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
            .UseSqlite("DataSource=:memory:");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);


            Status status = new Status { Id = 1, Name = "AVAILABLE", };

            await context.Statuses.AddAsync(status);
            await context.SaveChangesAsync();

            //Act

            StatusGetDto result = await statusRepository.GetByIdAsync(2);

            //Assert

            Assert.IsNull(result);
        }
    }


    [TestMethod]

    public async Task GetByIdAsyncTest_Id_BadRequest()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite("DataSource=:memory:");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            StatusRepository statusRepository = new StatusRepository(context);

            Status status = new Status { Id = 1, Name = "AVAILABLE", };

            await context.Statuses.AddAsync(status);
            await context.SaveChangesAsync();

            //Act

            await statusRepository.GetByIdAsync(-2);

            // Assert

            Assert.AreEqual(400, (int)HttpStatusCode.BadRequest);
        }
    }
}