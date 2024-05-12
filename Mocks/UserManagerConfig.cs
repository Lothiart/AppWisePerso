using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Mocks;

public static class UserManagerConfig
{
    public static UserManager<AppUser> CreateUserManager(DriveWiseContext context)
    {
        UserStore<AppUser> store = new UserStore<AppUser>(context);
        UserManager<AppUser> userManager = new UserManager<AppUser>(
            store,
            null,
            new PasswordHasher<AppUser>(),
            new IUserValidator<AppUser>[0],
            new IPasswordValidator<AppUser>[0],
            null,
            null,
            null,
            null
        );
        return userManager;
    }
}
