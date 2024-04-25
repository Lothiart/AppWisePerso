using DTOs.DTOs.CollaboratorDTOs;
using Entities;
using Entities.Contexts;
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
        DriveWiseContext context;
        ILogger<CityRepository> logger;

        public CollaboratorRepository(DriveWiseContext context, ILogger<CityRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        //public async Task<CollaboratorGetDto> GetByIdAsync(int id)
        //{
        //    Collaborator collaborateur = await context.Collaborators.FirstOrDefaultAsync(c => c.AppUserId == id);

        //    return new CollaboratorGetDto() { Id = id, FirstName = collaborateur.FirstName, LastName = collaborateur.LastName, Email = collaborateur.AppUser.Email };
        //}

        //public async Task<CollaboratorGetPersoDto> GetFullUserByIdAsync(string id)
        //{
        //    Collaborator collaborateur = await context.Collaborators.FirstOrDefaultAsync(c => c.AppUserId == id);

        //    return new CollaboratorGetPersoDto() { Id = id, FirstName = collaborateur.FirstName, LastName = collaborateur.LastName, Email = collaborateur.AppUser.Email, CarpoolsAsDriver = await context.Carpools.Where(c => c.DriverId == id).ToListAsync(), 
        //        CarpoolsAsPassenger = await driveWiseContext.Carpools.Include(c => c.Passengers).ToListAsync()};
           
        //}
    }
}
