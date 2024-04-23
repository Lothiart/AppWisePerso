using Entities;

namespace DTOs.CollaboratorDTOs;

public class CollaboratorAddDto
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public AppUser AppUser { get; set; }
}