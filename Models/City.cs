namespace Entities;

public class City
{
    public int Id { get; set; } //ok

    public string Name { get; set; } //ok

    public int ZipCode { get; set; } //ok

    public List<Address> Addresses { get; set; } //ok
}
