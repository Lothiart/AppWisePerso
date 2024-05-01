using Entities.Const;
using Services.DTOs.CollaboratorDTOs;
using Entities;
using Entities.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.Contracts;



namespace Repositories
{
    public class CollaboratorRepository(DriveWiseContext context,
    ILogger<CityRepository> logger,
    UserManager<AppUser> userManager) : ICollaboratorRepository
    {
        public async Task<Collaborator> AddAsync(Collaborator collaborator)
        {
            try
            {
                await context
                    .Collaborators
                    .AddAsync(collaborator);

                await context.SaveChangesAsync();
                return collaborator;
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }
        public async Task<CollaboratorGetDto> GetByIdAsync(int id)
        {
            try
            {
                Collaborator collaborator = await context.Collaborators.FirstOrDefaultAsync(c => c.Id == id);


                AppUser user = await context.Users.FirstOrDefaultAsync(u => u.Id == collaborator.AppUserId);
                return new CollaboratorGetDto() { Id = user.Collaborator.Id, FirstName = user.Collaborator.FirstName, LastName = user.Collaborator.LastName, Email = user.Email };

            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task<CollaboratorGetFullUserDto> GetFullUserByIdAsync(int id)
        {
            try
            {
                Collaborator collaborator = await context.Collaborators.FirstOrDefaultAsync(c => c.Id == id);

                AppUser user = await context.Users.FirstOrDefaultAsync(c => c.Id == collaborator.AppUserId);

                return new CollaboratorGetFullUserDto()
                {
                    Id = user.Collaborator.Id,
                    FirstName = user.Collaborator.FirstName,
                    LastName = user.Collaborator.LastName,
                    Email = user.Email,
                    CarpoolsAsDriver = await context.Carpools.Where(c => c.DriverId == user.Collaborator.Id).ToListAsync(),
                    CarpoolsAsPassenger = await context.Carpools.Include(c => c.Passengers).ToListAsync()
                };
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }

        public async Task GiveAdminRoleAsync(int id)
        {
            try
            {
                Collaborator collaborator = await context.Collaborators.FirstOrDefaultAsync(c => c.Id == id);

                AppUser user = await context.Users.FirstOrDefaultAsync(c => c.Id == collaborator.AppUserId);
                await userManager.AddToRoleAsync(user, ROLES.ADMIN);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                logger.LogError(e!.InnerException!.Message);
                throw;
            }
        }
    }
}
