using Services.DTOs.CollaboratorDTOs;
using Entities;

namespace Repositories.Contracts;

public interface ICollaboratorRepository
{
    Task<Collaborator> AddAsync(Collaborator collaborator);
    Task<CollaboratorGetFullUserDto> GetFullUserByIdAsync(int id);
    Task<CollaboratorGetDto> GetByIdAsync(int id);
    Task GiveAdminRoleAsync(int id);
}
