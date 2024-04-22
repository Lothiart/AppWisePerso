using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Name", IsUnique = true)]
public class Category
{
    public int Id { get; set; }  //ok

    public string Name { get; set; } //ok

    public List<Vehicle> Vehicles { get; set; } //ok
}
