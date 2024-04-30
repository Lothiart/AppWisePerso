using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.DTOs.StatusDTOs;


namespace RepositoriesTests;

[TestClass]
public class StatusRepositoryTest
{
    [TestMethod]
    public async void GetAllAsyncTest()
    {
        //Arrange

        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>().UseInMemoryDatabase("DriveWiseTest");
        DriveWiseContext _context = new DriveWiseContext(builder.Options);
        _context.Database.EnsureDeleted();

        StatusRepository statusRepository = new StatusRepository(_context);


        List<Status> statuses = new List<Status>
        {
            new Status { Id = 1,Name = "AVAIBLE",},
            new Status { Id = 1, Name = "INREPAIR",}
        };

        await _context.Statuses.AddRangeAsync(statuses);
        await _context.SaveChangesAsync();

        //Act

        List<StatusGetDto> result = await statusRepository.GetAllAsync();

        //Assert

        Assert.AreEqual(statuses.Count, result.Count);
    }
}