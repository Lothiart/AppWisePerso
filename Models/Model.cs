namespace Entities;

public class Model
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImgUrl { get; set; }
    public List<Vehicle> Vehicles { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }
}