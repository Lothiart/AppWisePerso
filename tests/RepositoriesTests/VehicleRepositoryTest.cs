using DTOs.Mappers;
using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories;
using Services.DTOs.VehicleDTOs;

namespace RepositoriesTests;


[TestClass]

public class VehicleRepositoryTest
{

    private string databasePath;

    [TestMethod]

    public async Task GetAllAsyncTest_Empty_VehicleList()
    {
        //Arrange

        // databasePath = "RepositoriesTests/DriveWiseDatabase.sqlite";


        DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
            .UseSqlite("DataSource=:memory:");

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            CategoryMapper categoryMapper = new CategoryMapper();

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });


            ILogger<CategoryRepository> loggerCategory = loggerFactory.CreateLogger<CategoryRepository>();
            ILogger<ModelRepository> loggerModel = loggerFactory.CreateLogger<ModelRepository>();
            ILogger<BrandRepository> loggerBrand = loggerFactory.CreateLogger<BrandRepository>();


            VehicleRepository vehicleRepository = new VehicleRepository(context);
            StatusRepository statusRepository = new StatusRepository(context);
            CategoryRepository categoryRepository = new CategoryRepository(context, categoryMapper, loggerCategory);
            MotorRepository motorRepository = new MotorRepository(context);
            ModelRepository modelRepository = new ModelRepository(context, loggerModel);
            BrandRepository brandRepository = new BrandRepository(context, loggerBrand);

            Status status = new Status { Id = 1, Name = "AVAILABLE", };

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine", },
                new Category { Id = 2, Name = "Berline", },
            };

            Motor motor = new Motor { Id = 1, Type = "Fuel", };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb" };
            Brand brand = new Brand { Id = 1, Name = "Peugeot", };

            await context.Statuses.AddAsync(status);
            await context.Categories.AddRangeAsync(categories);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.Brands.AddAsync(brand);

            await context.SaveChangesAsync();


            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId =1,
                    MotorId =1,
                    ModelId =1,
                    BrandId =1
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId =2,
                    MotorId =1,
                    ModelId =1,
                    BrandId =1
                }
            };

            // await context.Statuses.AddAsync(status);
            // await context.Categories.AddRangeAsync(categories);
            // await context.Motors.AddAsync(motor);
            // await context.Models.AddAsync(model);
            // await context.Brands.AddAsync(brand);

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            //Act

            List<VehicleGetAdminDto> result = await vehicleRepository.GetAllAdminAsync();

            //Assert

            Assert.AreEqual(vehicles.Count, result.Count);

        }
    }
}
