using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.Contexts;
public class DriveWiseContext : IdentityDbContext<AppUser>
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Carpool> Carpools { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Collaborator> Collaborators { get; set; }
    public DbSet<Date> Dates { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Motor> Motors { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DriveWiseContext(DbContextOptions<DriveWiseContext> contextOptions) : base(contextOptions) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Carpool>()
            .HasMany(c => c.Passengers)
            .WithMany(c => c.CarpoolsAsPassenger);

        modelBuilder
            .Entity<Carpool>()
            .HasOne(navigationExpression: c => c.Driver)
            .WithMany(c => c.CarpoolsAsDriver)
            .HasForeignKey(c => c.DriverId);

        modelBuilder
            .Entity<Date>()
            .HasMany(navigationExpression: d => d.RentalStarts)
            .WithOne(d => d.StartDate)
            .HasForeignKey(d => d.StartDateId);

        modelBuilder
            .Entity<Date>()
            .HasMany(navigationExpression: d => d.RentalEnds)
            .WithOne(d => d.EndDate)
            .HasForeignKey(d => d.EndDateId);

        modelBuilder
            .Entity<Address>()
            .HasMany(navigationExpression: c => c.CarpoolStartAdresses)
            .WithOne(c => c.StartAddress)
            .HasForeignKey(c => c.StartAddressId);

        modelBuilder
            .Entity<Address>()
            .HasMany(navigationExpression: c => c.CarpoolEndAdresses)
            .WithOne(c => c.EndAddress)
            .HasForeignKey(c => c.EndAddressId);

        modelBuilder
            .Entity<IdentityRole>()
            .HasData(new List<IdentityRole>()
                {
                    new IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" },
                    new IdentityRole { Name = "COLLABORATOR", NormalizedName = "COLLABORATOR" },
                });

        modelBuilder
            .Entity<Status>()
            .HasData(new List<Status>()
                {
                    new Status { Id = 1, Name = STATUS.AVAILABLE },
                    new Status { Id = 2, Name = STATUS.INREPAIR },
                    new Status { Id = 3, Name = STATUS.OUTOFSERVICE },
                });

        base.OnModelCreating(modelBuilder);
    }
}
