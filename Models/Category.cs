using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Name", IsUnique = true)]
public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<Vehicle> Vehicles { get; set; }
}
