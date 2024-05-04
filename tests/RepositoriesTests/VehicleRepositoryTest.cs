using Entities;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Services.DTOs.VehicleDTOs;

namespace RepositoriesTests;

[TestClass]

public class VehicleRepositoryTest
{

    private const string DATABASE_PATH = "DriveWiseDatabase.sqlite";

    DbContextOptionsBuilder<DriveWiseContext> builder = new DbContextOptionsBuilder<DriveWiseContext>()
        .UseSqlite($"DataSource={DATABASE_PATH}");

    [TestMethod]

    public async Task GetAllAdminAsyncTest_Empty_VehicleList()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine" },
                new Category { Id = 2, Name = "Berline" },
            };

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };


            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Categories.AddRangeAsync(categories);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();


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
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine" },
                new Category { Id = 2, Name = "Berline" },
            };

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };


            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Categories.AddRangeAsync(categories);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();


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

            List<VehicleGetAdminDto> result = await vehicleRepository.GetAllByCategoryAdminAsync(2);

            //Assert

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("ke-658-de", result[0].Registration);
        }
    }


    [TestMethod]

    public async Task GetAllByCategoryAsyncTest_Id_Null()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine" },
                new Category { Id = 2, Name = "Berline" },
            };

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };


            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Categories.AddRangeAsync(categories);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();


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

            List<VehicleGetAdminDto> result = await vehicleRepository.GetAllByCategoryAdminAsync(6);

            //Assert

            Assert.AreEqual(0, result.Count);
        }
    }


    [TestMethod]

    public async Task GetByIdAdminAsyncTest_Id_SingleVehicle()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine" },
                new Category { Id = 2, Name = "Berline" },
            };

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };


            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Categories.AddRangeAsync(categories);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();


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

    public async Task GetByIdAdminAsyncTest_Id_Null()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

            List<Category> categories = new List<Category>
            {
                new Category { Id = 1, Name = "Citadine" },
                new Category { Id = 2, Name = "Berline" },
            };

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };


            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "vbnjhb", BrandId = 1 };

            await context.Categories.AddRangeAsync(categories);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();


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

            //Assert

            Assert.IsNull(result);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(DbUpdateException))]

    public async Task AddAdminAsyncTest_VehicleAdminDto_DbUpdateException()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

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
            };


            VehicleAdminDto vehicleAdminDto = new VehicleAdminDto
            {
                Registration = vehicle.Registration,
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

            await vehicleRepository.AddAdminAsync(vehicleAdminDto);
        }
    }


    [TestMethod]

    public async Task AddAdminAsyncTest_VehicleAdminDto_VehicleAdminDto()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

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
            };


            VehicleAdminDto vehicleAdminDto = new VehicleAdminDto
            {
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

            VehicleAdminDto result = await vehicleRepository.AddAdminAsync(vehicleAdminDto);

            // Assert

            Assert.AreEqual(vehicleAdminDto.CO2EmissionKm, result.CO2EmissionKm);
        }
    }


    [TestMethod]

    public async Task UpdateAsyncTest_VehicleUpdateDto_Vehicle()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

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

            Vehicle result = await vehicleRepository.UpdateAdminAsync(vehicleUpdateDto);

            // Assert

            Assert.AreEqual(vehicleUpdateDto.Registration, result.Registration);
        }
    }


    [TestMethod]

    public async Task UpdateAsyncTest_VehicleUpdateDto_Null()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

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

            Vehicle result = await vehicleRepository.UpdateAdminAsync(vehicleUpdateDto);

            // Assert

            Assert.IsNull(result);
        }
    }


    [TestMethod]

    public async Task DeleteAsyncTest_Int_Vehicle()
    {
        //Arrange

        using (DriveWiseContext context = new DriveWiseContext(builder.Options))
        {

            context.Database.EnsureDeleted();
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            VehicleRepository vehicleRepository = new VehicleRepository(context);

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
