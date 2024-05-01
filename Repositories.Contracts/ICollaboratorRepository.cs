using Services.DTOs.CollaboratorDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface ICollaboratorRepository
    {
        Task<Collaborator> AddAsync(Collaborator collaborator);
        Task<CollaboratorGetFullUserDto> GetFullUserByIdAsync(int id);
        Task<CollaboratorGetDto> GetByIdAsync(int id);
        Task GiveAdminRoleAsync(int id);
    }
}
