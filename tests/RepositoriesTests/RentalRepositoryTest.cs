using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.DTOs.RentalDTOs;

namespace RepositoriesTests;

public class MockUserManager : IUserStore<AppUser>, IUserPasswordStore<AppUser>
{
    public AppUser AppUser { get; set; } = new AppUser();

    public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
    {
        user.Id = Guid.NewGuid().ToString();
        return Task.FromResult(IdentityResult.Success);
    }

    public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<AppUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string?> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken) => Task.FromResult(string.Empty);

    public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken) => Task.CompletedTask;

    public Task SetUserNameAsync(AppUser user, string? userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}


[TestClass]

public class RentalRepositoryTest
{
    private const string DATABASE_PATH = "DriveWiseDatabase.sqlite";

    private DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
        .UseSqlite($"DataSource={DATABASE_PATH}");





    // [TestMethod]
    // public async Task AddAsyncTest_RentalAddDto_RentalAddDto()
    // {

    // }







    [TestMethod]

    public async Task GetAllCurrentAsyncTest_Empty_RentalGetDtoList()
    {
        //Arrange


        var userStore = new MockUserManager();
        var userManager = new UserManager<AppUser>(
            userStore,
            null,
            new PasswordHasher<AppUser>(),
            new List<IUserValidator<AppUser>>(),
            new[] { new PasswordValidator<AppUser>() },
            null,
            null,
            null,
            null
        );


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            RentalRepository rentalRepository = new RentalRepository(context);

            //// Create Vehicule

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Category category = new Category { Id = 1, Name = "Citadine" };
            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Categories.AddAsync(category);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();


            Vehicle vehicle = new Vehicle
            {
                Registration = "dw-082-gf",
                TotalSeats = 5,
                CO2EmissionKm = 3,
                StatusId = 1,
                CategoryId = 1,
                MotorId = 1,
                ModelId = 1,
                BrandId = 1
            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();


            //// Create Dates


            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(2) },
                new Date { Id = DateTime.Now.AddDays(3) }
            };

            await context.Dates.AddRangeAsync(listDate);
            await context.SaveChangesAsync();


            //// Create Collaborator


            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            var answer = await userManager.CreateAsync(appUser, "Motddepasse-1");
            await context.SaveChangesAsync();

            if (answer.Succeeded)
            {
                Collaborator collaborator = new Collaborator
                {
                    Id = 1,
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                };
                var test = await context.Collaborators.AddAsync(collaborator);
                await context.SaveChangesAsync();
            }




            Rental rental = new Rental
            {
                VehicleId = 1,
                CollaboratorId = 1,
                StartDateId = listDate[0].Id,
                EndDateId = listDate[1].Id,
            };

            await context.Rentals.AddAsync(rental);
            await context.SaveChangesAsync();

            // Act

            List<RentalGetDto> result = await rentalRepository.GetAllCurrentAsync();

            // Assert

            Assert.AreEqual(1, result.Count);

        }
    }
}
