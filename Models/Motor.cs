using Microsoft.EntityFrameworkCore;

namespace Entities;

[Index("Type", IsUnique = true)]

public class Motor
{
    public int Id { get; set; }

    public string Type { get; set; }

    public List<Vehicle> Vehicles { get; set; }
}
