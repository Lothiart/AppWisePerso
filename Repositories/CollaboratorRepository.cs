using Entities.Const;
using DTOs.DTOs.CityDTOs;
using DTOs.DTOs.CollaboratorDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        DriveWiseContext driveWiseContext;
        ILogger<CityRepository> logger;
        UserManager<AppUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public CollaboratorRepository(DriveWiseContext driveWiseContext, ILogger<CityRepository> logger,UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.driveWiseContext = driveWiseContext;
            this.logger = logger;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<CollaboratorGetDto> GetByIdAsync(AppUser appUser)
        {
            try
            {
                AppUser user = await driveWiseContext.Users.FirstOrDefaultAsync(u => u.Id == appUser.Id);
            return new CollaboratorGetDto() { Id = user.Collaborator.Id, FirstName = user.Collaborator.FirstName, LastName = user.Collaborator.LastName, Email = user.Email };

            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task<CollaboratorGetPersoDto> GetByIdPersoAsync(AppUser appUser)
        {
            try
            {
                AppUser user = await driveWiseContext.Users.FirstOrDefaultAsync(c => c.Id == appUser.Id);

                return new CollaboratorGetPersoDto()
                {
                    Id = user.Collaborator.Id,
                    FirstName = user.Collaborator.FirstName,
                    LastName = user.Collaborator.LastName,
                    Email = user.Email,
                    CarpoolsAsDriver = await driveWiseContext.Carpools.Where(c => c.DriverId == user.Collaborator.Id).ToListAsync(),
                    CarpoolsAsPassenger = await driveWiseContext.Carpools.Include(c => c.Passengers).ToListAsync()
                };
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task GiveAdminRoleAsync(AppUser appUser)
        {
            try
            {
                await userManager.AddToRoleAsync(appUser, ROLES.ADMIN);
                await driveWiseContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }
    }
}
