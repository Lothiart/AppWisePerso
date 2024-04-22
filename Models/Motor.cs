using Microsoft.EntityFrameworkCore;

namespace Entities;

[Index("Type", IsUnique = true)]

public class Motor
{
    public int Id { get; set; } //ok

    public string Type { get; set; } //ok

    public List<Vehicle> Vehicles { get; set; } //ok
}
