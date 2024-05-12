using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mocks;
using Repositories;
using Services.DTOs.VehicleDTOs;

namespace RepositoriesTests;

[TestClass]

public class VehicleRepositoryTest
{

    private const string DATABASE_PATH = "DriveWiseDatabase.sqlite";

    private DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
                                                                    .UseSqlite($"DataSource={DATABASE_PATH}");


    [TestInitialize]

    public async Task InitializeAsync()
    {
        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            // Create Categories

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine" },
                new Category { Id = 2, Name = "Berline" },
            };

            // Create Brand

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };

            // Create Motor

            Motor motor = new Motor { Id = 1, Type = "Fuel" };

            await context.Categories.AddRangeAsync(categories);
            await context.Brands.AddAsync(brand);
            await context.Motors.AddAsync(motor);
            await context.SaveChangesAsync();

            // Create Model

            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();

        }
    }


    [TestMethod]

    public async Task GetAllAdminAsyncTest_Empty_VehicleList()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            //Act

            List<VehicleGetAdminDto> result = await vehicleRepository.GetAllAdminAsync();

            //Assert

            Assert.AreEqual(vehicles.Count, result.Count);
            Assert.AreEqual(vehicles[1].CO2EmissionKm, result[1].CO2EmissionKm);
        }
    }


    [TestMethod]

    public async Task GetAllByCategoryAsyncTest_Id_VehicleList()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            //Act

            List<VehicleGetAdminDto> result = await vehicleRepository.GetAllByCategoryIdAdminAsync(2);

            //Assert

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ke-658-de", result[0].Registration);
        }
    }


    [TestMethod]

    public async Task GetAllByCategoryAsyncTest_Id_Null()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            //Act

            List<VehicleGetAdminDto> result = await vehicleRepository.GetAllByCategoryIdAdminAsync(6);

            //Assert

            Assert.AreEqual(0, result.Count);
        }
    }


    [TestMethod]

    public async Task GetAllByDatesAsyncTest_VehicleByDateDto_ListVehicleRentalDto_NoRentals()
    {

        // Vehicules have No Rentals

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            //Create VehicleByDateDto

            VehicleByDateDto vehicleByDateDto = new VehicleByDateDto
            {
                StartDateId = DateTime.Now,
                EndDateId = DateTime.Now.AddDays(2)
            };

            //Create Vehicles

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            // Act

            List<VehicleRentalDto> result = await vehicleRepository.GetAllByDatesAsync(vehicleByDateDto);

            // Assert

            Assert.AreEqual(vehicles.Count(), result.Count());
        }
    }


    [TestMethod]

    public async Task GetAllByDatesAsyncTest_VehicleByDateDto_ListVehicleRentalDto_WithRentals()
    {

        // Vehicules have Rentals


        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            // Create User

            UserStore<AppUser> store = new UserStore<AppUser>(context);
            UserManager<AppUser> _userManager = new UserManager<AppUser>(
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

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

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

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(2) },
                new Date { Id = DateTime.Now.AddDays(3) },
                new Date { Id = DateTime.Now.AddDays(4) },
                new Date { Id = DateTime.Now.AddDays(5) },
                new Date { Id = DateTime.Now.AddDays(6) },
                new Date { Id = DateTime.Now.AddDays(7) },
            };

            await context.Dates.AddRangeAsync(listDate);
            await context.SaveChangesAsync();


            //Create VehicleByDateDto

            VehicleByDateDto vehicleByDateDto = new VehicleByDateDto
            {
                StartDateId = listDate[0].Id,
                EndDateId = listDate[2].Id
            };

            //Create Vehicles

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            // Create Rentals

            List<Rental> Rentals = new List<Rental>
            {
                new Rental
                {
                    VehicleId = 1,
                    CollaboratorId = 1,
                    StartDateId = listDate[0].Id,
                    EndDateId = listDate[2].Id,
                },

                new Rental
                {
                    VehicleId = 2,
                    CollaboratorId = 1,
                    StartDateId = listDate[3].Id,
                    EndDateId = listDate[5].Id,
                }
            };

            await context.Rentals.AddRangeAsync(Rentals);
            await context.SaveChangesAsync();


            // Act

            List<VehicleRentalDto> result = await vehicleRepository.GetAllByDatesAsync(vehicleByDateDto);

            // Assert

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("ke-658-de", result[0].Registration);

        }
    }


    [TestMethod]

    public async Task GetAllByDatesAsyncTest_VehicleByDateDto_ListVehicleRentalDto()
    {

        // Status test

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            //Create VehicleByDateDto

            VehicleByDateDto vehicleByDateDto = new VehicleByDateDto
            {
                StartDateId = DateTime.Now,
                EndDateId = DateTime.Now.AddDays(2)
            };

            //Create Vehicles

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 2,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "yt-568-fg",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 3,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            // Act

            List<VehicleRentalDto> result = await vehicleRepository.GetAllByDatesAsync(vehicleByDateDto);

            // Assert

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("dw-082-gf", result[0].Registration);

        }
    }


    [TestMethod]

    public async Task GetByIdAdminAsyncTest_Id_VehicleGetAdminDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            // Act

            VehicleGetAdminDto result = await vehicleRepository.GetByIdAdminAsync(1);

            //Assert

            Assert.AreEqual(vehicles[0].TotalSeats, result.TotalSeats);
            Assert.AreEqual(vehicles[0].StatusId, result.StatusId);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]

    public async Task GetByIdAdminAsyncTest_Id_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Registration = "dw-082-gf",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                },
                new Vehicle
                {
                    Registration = "ke-658-de",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 2,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();

            // Act

            VehicleGetAdminDto result = await vehicleRepository.GetByIdAdminAsync(3);


        }
    }


    [TestMethod]
    [ExpectedException(typeof(DbUpdateException))]

    // test the "unique"registration

    public async Task AddAdminAsyncTest_VehicleAdminDto_DbUpdateException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

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


            VehicleAdminDto vehicleAdminDto = new VehicleAdminDto
            {
                Registration = vehicle.Registration,
                TotalSeats = 8,
                CO2EmissionKm = 2,
                CategoryId = 1,
                MotorId = 1,
                ModelId = 1,
                StatusId = 1,

            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            // Act

            await vehicleRepository.AddAdminAsync(vehicleAdminDto);
        }
    }


    [TestMethod]

    public async Task AddAdminAsyncTest_VehicleAdminDto_VehicleAdminDto()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

            VehicleAdminDto vehicleAdminDto = new VehicleAdminDto
            {
                Registration = "ko-325-lp",
                TotalSeats = 5,
                CO2EmissionKm = 3,
                CategoryId = 1,
                MotorId = 1,
                ModelId = 1,
                StatusId = 1,
            };

            // Act

            VehicleAdminDto result = await vehicleRepository.AddAdminAsync(vehicleAdminDto);

            // Assert

            Assert.AreEqual("ko-325-lp", result.Registration);
            Assert.AreEqual(5, result.TotalSeats);
            Assert.AreEqual(3, result.CO2EmissionKm);
            Assert.AreEqual(1, result.CategoryId);
            Assert.AreEqual(1, result.MotorId);
            Assert.AreEqual(1, result.ModelId);
            Assert.AreEqual(1, result.StatusId);

        }
    }


    [TestMethod]

    public async Task UpdateAdminAsyncTest_VehicleUpdateDto_Vehicle()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

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

            VehicleUpdateDto vehicleUpdateDto = new VehicleUpdateDto
            {
                Id = 1,
                Registration = "ko-325-lp",
                TotalSeats = vehicle.TotalSeats,
                CO2EmissionKm = vehicle.CO2EmissionKm,
                CategoryId = vehicle.CategoryId,
                MotorId = vehicle.MotorId,
                ModelId = vehicle.ModelId,
                StatusId = vehicle.StatusId

            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            // Act

            VehicleUpdateDto result = await vehicleRepository.UpdateAdminAsync(vehicleUpdateDto);

            // Assert

            Assert.AreEqual(vehicleUpdateDto.Registration, result.Registration);
        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]


    public async Task UpdateAdminAsyncTest_VehicleUpdateDto_KeyNotFoundException()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

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


            VehicleUpdateDto vehicleUpdateDto = new VehicleUpdateDto
            {
                Id = 15,
                Registration = "ko-325-lp",
                TotalSeats = vehicle.TotalSeats,
                CO2EmissionKm = vehicle.CO2EmissionKm,
                CategoryId = vehicle.CategoryId,
                MotorId = vehicle.MotorId,
                ModelId = vehicle.ModelId,
                StatusId = vehicle.StatusId

            };

            await context.Vehicles.AddAsync(vehicle);
            await context.SaveChangesAsync();

            // Act

            VehicleUpdateDto result = await vehicleRepository.UpdateAdminAsync(vehicleUpdateDto);

        }
    }


    [TestMethod]

    public async Task DeleteAdminAsyncTest_Int_Vehicle()
    {

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<VehicleRepository> logger = new MockLogger<VehicleRepository>();

            VehicleRepository vehicleRepository = new VehicleRepository(context, logger);

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

            // Act

            await vehicleRepository.DeleteAdminAsync(1);

            // Assert
            Vehicle? result = await context.Vehicles.FirstOrDefaultAsync(v => v.Id == 1);

            Assert.IsNull(result);
        }
    }
}
