using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mocks;
using Repositories;
using Services.DTOs.RentalDTOs;

namespace RepositoriesTests;


[TestClass]

public class RentalRepositoryTest
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

            Brand brand = new Brand { Id = 1, Name = "Peugeot" };

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();

            Category category = new Category { Id = 1, Name = "Citadine" };
            Motor motor = new Motor { Id = 1, Type = "Fuel" };
            Model model = new Model { Id = 1, Name = "208", ImgUrl = "http://test.fr", BrandId = 1 };

            await context.Categories.AddAsync(category);
            await context.Motors.AddAsync(motor);
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();

            List<Vehicle> vehicleList = new List<Vehicle>
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
                    Registration = "ap-826-hj",
                    TotalSeats = 5,
                    CO2EmissionKm = 3,
                    StatusId = 1,
                    CategoryId = 1,
                    MotorId = 1,
                    ModelId = 1,
                }
            };

            await context.Vehicles.AddRangeAsync(vehicleList);
            await context.SaveChangesAsync();

        }
    }


    [TestMethod]

    public async Task AddAsyncTest_RentalAddDto_RentalAddDto()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            // Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            //Create Rental

            RentalAddDto rental = new RentalAddDto
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = DateTime.Now.AddDays(2),
                EndDateId = DateTime.Now.AddDays(3),
            };

            // Act

            RentalAddDto result = await rentalRepository.AddAsync(rental, appUser);

            //Assert

            Assert.AreEqual(1, result.VehicleId);
            Assert.AreEqual(1, result.CollaboratorId);
            Assert.AreEqual(rental.StartDateId, result.StartDateId);
            Assert.AreEqual(rental.EndDateId, result.EndDateId);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]


    public async Task AddAsyncTest_RentalAddDto_KeyNotFoundException()
    {
        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            // Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(1) },
                new Date { Id = DateTime.Now.AddDays(5) },
            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();

            // Create Rentals

            Rental rental = new Rental
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[0].Id,
                EndDateId = listDate[1].Id,
            };

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();


            RentalAddDto rentalTest = new RentalAddDto
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = DateTime.Now.AddDays(2),
                EndDateId = DateTime.Now.AddDays(4),
            };

            // Act

            RentalAddDto result = await rentalRepository.AddAsync(rentalTest, appUser);

        }
    }



    [TestMethod]

    public async Task GetAllCurrentUserAsyncTest_Empty_RentalGetDtoList()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create appUser and Collaborator

            AppUser Jean = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(Jean, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = Jean.Id,
                });
            }

            // Create appUser and Collaborator  nº2

            AppUser Martine = new AppUser
            {
                UserName = "Martine@Dup.ont",
                Email = "Martine@Dup.ont"
            };

            IdentityResult answer2 = await _userManager.CreateAsync(Martine, "Motdepasse-1");

            if (answer2.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Martine",
                    LastName = "Dupont",
                    AppUserId = Martine.Id,
                });
            }

            await _context.SaveChangesAsync();

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(-3) },
                new Date { Id = DateTime.Now.AddDays(-2) },
                new Date { Id = DateTime.Now.AddDays(-1) },
                new Date { Id = DateTime.Now.AddDays(3) },
            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();

            // Create Rental

            List<Rental> rentals = new List<Rental>
            {
                new Rental
                {
                    VehicleId = 1,
                    CollaboratorId = Jean.Collaborator.Id,
                    StartDateId = listDate[0].Id,
                    EndDateId = listDate[1].Id,
                },
                new Rental
                {
                    VehicleId = 2,
                    CollaboratorId = Jean.Collaborator.Id,
                    StartDateId = listDate[2].Id,
                    EndDateId = listDate[3].Id,
                },
                new Rental
                {
                    VehicleId = 1,
                    CollaboratorId = Martine.Collaborator.Id,
                    StartDateId = listDate[2].Id,
                    EndDateId = listDate[3].Id,
                }
            };

            await _context.Rentals.AddRangeAsync(rentals);
            await _context.SaveChangesAsync();


            // Act

            List<RentalGetDto> result = await rentalRepository.GetAllCurrentsUserAsync(Jean);

            // Assert

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(rentals[1].StartDateId, result[0].StartDate);

        }
    }


    [TestMethod]

    public async Task GetAllPastAsyncTest_Empty_RentalGetDtoList()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(-2) },
                new Date { Id = DateTime.Now.AddDays(-3) },
                new Date { Id = DateTime.Now.AddDays(5) },
                new Date { Id = DateTime.Now.AddDays(7) },

            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();

            // Create Rental

            List<Rental> rentals = new List<Rental>
            {
                new Rental
                {
                    VehicleId = 1,
                    CollaboratorId = appUser.Collaborator.Id,
                    StartDateId = listDate[0].Id,
                    EndDateId = listDate[1].Id,
                },
                new Rental
                {
                    VehicleId = 1,
                    CollaboratorId = appUser.Collaborator.Id,
                    StartDateId = listDate[2].Id,
                    EndDateId = listDate[3].Id,
                }
            };

            await _context.Rentals.AddRangeAsync(rentals);
            await _context.SaveChangesAsync();

            // Act

            List<RentalGetDto> result = await rentalRepository.GetAllPastsUserAsync(appUser);

            // Assert

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(rentals[0].StartDateId, result[0].StartDate);

        }
    }


    [TestMethod]

    public async Task UpdateAsyncTest_RentalUpdateDto_RentalUpdateDto_NoCarpool()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(2) },
                new Date { Id = DateTime.Now.AddDays(3) },
                new Date { Id = DateTime.Now.AddDays(5) },
                new Date { Id = DateTime.Now.AddDays(7) },

            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();

            // Create Rental

            Rental rental = new Rental
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[0].Id,
                EndDateId = listDate[1].Id,
            };


            RentalUpdateDto rentalUpdateDto = new RentalUpdateDto
            {
                Id = 1,
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[2].Id,
                EndDateId = listDate[3].Id,
            };

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();

            // Act

            RentalUpdateDto result = await rentalRepository.UpdateAsync(rentalUpdateDto, appUser);

            // Assert

            Assert.AreEqual(rentalUpdateDto.StartDateId, result.StartDateId);
            Assert.AreEqual(rentalUpdateDto.EndDateId, result.EndDateId);

        }
    }


    [TestMethod]

    public async Task UpdateAsyncTest_RentalUpdateDto_RentalUpdateDto_WithCarpool()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(2) },
                new Date { Id = DateTime.Now.AddDays(3) },
                new Date { Id = DateTime.Now.AddDays(4) },
                new Date { Id = DateTime.Now.AddDays(5) },
                new Date { Id = DateTime.Now.AddDays(7) },

            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();

            // Create Rental

            Rental rental = new Rental
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[1].Id,
                EndDateId = listDate[4].Id,
            };

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
            /// Create Cities

            List<City> cities = new List<City>
            {
                new City
                {
                    Name = "Montpellier",
                    ZipCode = 34000
                },
                new City
                {
                    Name = "Montigny-le-bretonneux ",
                    ZipCode = 78180
                }
            };

            await _context.Cities.AddRangeAsync(cities);
            await _context.SaveChangesAsync();

            /// Create Addresses

            List<Address> addresses = new List<Address>
            {
                new Address
                {
                    Line1 = "22 rue de la gare ",
                    Line2 = "Apt 32",
                    CityId = 1,
                },
                new Address
                {
                    Line1 = "25 grand rue ",
                    Line2 = "Apt 12",
                    CityId = 2,
                }
            };

            await _context.Addresses.AddRangeAsync(addresses);
            await _context.SaveChangesAsync();

            /// Create Carpool

            Carpool carpool = new Carpool
            {
                StartAddressId = 1,
                EndAddressId = 2,
                DateId = listDate[3].Id,
                RentalId = 1,
                DriverId = appUser.Collaborator.Id
            };

            await _context.Carpools.AddAsync(carpool);
            await _context.SaveChangesAsync();

            // Datas to Update current rental

            RentalUpdateDto rentalUpdateDto = new RentalUpdateDto
            {
                Id = 1,
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[2].Id,
                EndDateId = listDate[4].Id,
            };

            // Act

            RentalUpdateDto result = await rentalRepository.UpdateAsync(rentalUpdateDto, appUser);

            // Assert

            Assert.AreEqual(rentalUpdateDto.StartDateId, result.StartDateId);
            Assert.AreEqual(rentalUpdateDto.EndDateId, result.EndDateId);

        }
    }


    [TestMethod]
    [ExpectedException(typeof(Exception))]

    public async Task UpdateAsyncTest_RentalUpdateDto_Exception_WithCarpool()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            //Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            // Create Dates

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(2) },
                new Date { Id = DateTime.Now.AddDays(3) },
                new Date { Id = DateTime.Now.AddDays(4) },
                new Date { Id = DateTime.Now.AddDays(5) },
                new Date { Id = DateTime.Now.AddDays(7) },

            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();

            // Create Rental

            Rental rental = new Rental
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[1].Id,
                EndDateId = listDate[4].Id,
            };

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
            /// Create Cities

            List<City> cities = new List<City>
            {
                new City
                {
                    Name = "Montpellier",
                    ZipCode = 34000
                },
                new City
                {
                    Name = "Montigny-le-bretonneux ",
                    ZipCode = 78180
                }
            };

            await _context.Cities.AddRangeAsync(cities);
            await _context.SaveChangesAsync();

            /// Create Addresses

            List<Address> addresses = new List<Address>
            {
                new Address
                {
                    Line1 = "22 rue de la gare ",
                    Line2 = "Apt 32",
                    CityId = 1,
                },
                new Address
                {
                    Line1 = "25 grand rue ",
                    Line2 = "Apt 12",
                    CityId = 2,
                }
            };

            await _context.Addresses.AddRangeAsync(addresses);
            await _context.SaveChangesAsync();

            /// Create Carpool

            Carpool carpool = new Carpool
            {
                StartAddressId = 1,
                EndAddressId = 2,
                DateId = listDate[2].Id,
                RentalId = 1,
                DriverId = appUser.Collaborator.Id
            };

            await _context.Carpools.AddAsync(carpool);
            await _context.SaveChangesAsync();

            // Datas to Update current rental

            RentalUpdateDto rentalUpdateDto = new RentalUpdateDto
            {
                Id = 1,
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[3].Id,
                EndDateId = listDate[4].Id,
            };

            // Act

            RentalUpdateDto result = await rentalRepository.UpdateAsync(rentalUpdateDto, appUser);

        }
    }


    [TestMethod]

    public async Task DeleteAsyncTest_Int_Rental()
    {

        using (DriveWiseContext _context = new DriveWiseContext(builder.Options))
        {

            // Arrange

            MockLogger<RentalRepository> rentalLogger = new MockLogger<RentalRepository>();
            MockLogger<VehicleRepository> vehicleLogger = new MockLogger<VehicleRepository>();

            DateRepository dateRepository = new DateRepository(_context);
            VehicleRepository vehicleRepository = new VehicleRepository(_context, vehicleLogger);
            RentalRepository rentalRepository = new RentalRepository(_context, dateRepository, vehicleRepository, rentalLogger);

            UserManager<AppUser> _userManager = UserManagerConfig.CreateUserManager(_context);

            // Create Collaborator

            AppUser appUser = new AppUser
            {
                UserName = "Jean@Mich.el",
                Email = "Jean@Mich.el"
            };

            IdentityResult answer = await _userManager.CreateAsync(appUser, "Motdepasse-1");

            if (answer.Succeeded)
            {

                await _context.Collaborators.AddAsync(new Collaborator
                {
                    FirstName = "Jean",
                    LastName = "Michel",
                    AppUserId = appUser.Id,
                });
            }

            await _context.SaveChangesAsync();

            List<Date> listDate = new List<Date>
            {
                new Date { Id = DateTime.Now.AddDays(2) },
                new Date { Id = DateTime.Now.AddDays(3) },
                new Date { Id = DateTime.Now.AddDays(5) },
                new Date { Id = DateTime.Now.AddDays(7) },

            };

            await _context.Dates.AddRangeAsync(listDate);
            await _context.SaveChangesAsync();


            Rental rental = new Rental
            {
                VehicleId = 1,
                CollaboratorId = appUser.Collaborator.Id,
                StartDateId = listDate[0].Id,
                EndDateId = listDate[1].Id,
            };

            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();

            // Act

            await rentalRepository.DeleteAsync(rental.Id, appUser);

            //Assert

            Rental? result = await _context.Rentals.FirstOrDefaultAsync(r => r.Id == 1);

            Assert.IsNull(result);

        }
    }
}
