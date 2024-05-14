using Entities;

namespace Services.DTOs.CollaboratorDTOs;

public class CollaboratorGetFullUserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public List<Carpool> CarpoolsAsDriver { get; set; }
    public List<Carpool> CarpoolsAsPassenger { get; set; }
}