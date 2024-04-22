using Microsoft.AspNetCore.Identity;

namespace Entities;

public class AppUser : IdentityUser
{
    public Collaborator? Collaborator { get; set; }

}
