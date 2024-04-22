namespace Entities;

public class City
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int ZipCode { get; set; }

    public List<Address> Addresses { get; set; }
}
