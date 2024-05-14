namespace Services.DTOs.AddressDTOs;

public class AddressGetDto : AddressAddDto
{
    public int Id { get; set; }
    public string City { get; set; }
}