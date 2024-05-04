using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.DTOs.RentalDTOs;

namespace RepositoriesTests;

// public class MockUserStore : IUserStore<AppUser>, IUserPasswordStore<AppUser>
// {

//     public Task<IdentityResult> CreateAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         user.Id = Guid.NewGuid().ToString();
//         return Task.FromResult(IdentityResult.Success);
//     }

//     public Task<IdentityResult> DeleteAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public void Dispose()
//     {
//         throw new NotImplementedException();
//     }

//     public Task<AppUser?> FindByIdAsync(string userId, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<AppUser?> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<string?> GetNormalizedUserNameAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<string?> GetPasswordHashAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<string> GetUserIdAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<string> GetUserNameAsync(AppUser user, CancellationToken cancellationToken) => Task.FromResult(string.Empty);

//     public Task<bool> HasPasswordAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task SetNormalizedUserNameAsync(AppUser user, string normalizedName, CancellationToken cancellationToken) => Task.CompletedTask;

//     public Task SetPasswordHashAsync(AppUser user, string passwordHash, CancellationToken cancellationToken) => Task.CompletedTask;

//     public Task SetUserNameAsync(AppUser user, string? userName, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }

//     public Task<IdentityResult> UpdateAsync(AppUser user, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }
// }


// public class MockUserManager : UserManager<AppUser>
// {
//     var store = new UserStore<AppUser>(context);

//     public MockUserManager() : base(


//          null,
//          new PasswordHasher<AppUser>(),
//          new List<IUserValidator<AppUser>>(),
//          new[] { new PasswordValidator<AppUser>() },
//          null,
//          null,
//          null,
//          null
//     )
//     {
//     }
// }


[TestClass]

public class RentalRepositoryTest
{
    private DbContextOptionsBuilder<DriveWiseContext> builder;
    private UserManager<AppUser> _userManager;
    private const string DATABASE_PATH = "DriveWiseDatabase.sqlite";
    private DriveWiseContext context;

    [TestInitialize]

    public async Task InitializeAsync()
    {

        builder = new DbContextOptionsBuilder<DriveWiseContext>()
                .UseSqlite($"DataSource={DATABASE_PATH}");


        using (context = new DriveWiseContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();



            var store = new UserStore<AppUser>(context);
            _userManager = new UserManager<AppUser>(
                store,
                null,
                new PasswordHasher<AppUser>(),
                new IUserValidator<AppUser>[0],
                new IPasswordValidator<AppUser>[0],
                null,
                null,
                null,
                null
            );


            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            var answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await context.SaveChangesAsync();

        }

    }







    // [TestMethod]
    // public async Task AddAsyncTest_RentalAddDto_RentalAddDto()
    // {

    // }







    [TestMethod]

    public async Task GetAllCurrentAsyncTest_Empty_RentalGetDtoList()
    {
        //Arrange


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {



            // var UserManager = new MockUserManager();

            // context.Database.EnsureDeleted();
            // context.Database.OpenConnection();
            // context.Database.EnsureCreated();

            RentalRepository rentalRepository = new RentalRepository(context);

            //// Create Vehicule

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };

            await context.Brands.AddAsync(brand);
            // await context.SaveChangesAsync();

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


            // AppUser appUser = new AppUser
            // {
            //     UserName = "Jean@Mich.el",
            //     Email = "Jean@Mich.el"
            // };

            // var answer = await UserManager.CreateAsync(appUser, "Motdepasse-1");
            // await context.SaveChangesAsync();

            // if (answer.Succeeded)
            // {

            //     await context.Collaborators.AddAsync(new Collaborator
            //     {
            //         Id = 1,
            //         FirstName = "Jean",
            //         LastName = "Michel",
            //         AppUserId = appUser.Id,
            //     });
            // }


            // await context.SaveChangesAsync();



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
