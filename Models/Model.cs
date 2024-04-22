using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Name", IsUnique = true)]
public class Model
{
    public int Id { get; set; } //ok

    public string Name { get; set; } //ok

    public string ImgUrl { get; set; } //ok

    public List<Vehicle> Vehicles { get; set; } //ok

    public int BrandId { get; set; } //ok

    public Brand Brand { get; set; } //ok
}
