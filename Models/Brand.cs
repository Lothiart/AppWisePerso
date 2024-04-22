using Microsoft.EntityFrameworkCore;


namespace Entities;

[Index("Name", IsUnique = true)]
public class Brand
{
    public int Id { get; set; } //ok

    public string Name { get; set; } //ok

    public int ModelId { get; set; } //ok

    public List<Model> Models { get; set; } //ok
}
