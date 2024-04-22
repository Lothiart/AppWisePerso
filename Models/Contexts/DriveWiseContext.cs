using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.Contexts;
public class DriveWiseContext : IdentityDbContext<Collaborator>
{
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Carpool> Carpools { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Collaborator> Collaborators { get; set; }
    public DbSet<Date> Dates { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Motor> Motor { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    public DriveWiseContext(DbContextOptions contextOptions) : base(contextOptions) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}
