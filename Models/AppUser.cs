using Microsoft.AspNetCore.Identity;

namespace Entities;

public class AppUser : IdentityUser
{
    public int CollaboratorId { get; set; }
    public Collaborator? Collaborator { get; set; }
}
