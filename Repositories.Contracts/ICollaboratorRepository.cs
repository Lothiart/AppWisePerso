using DTOs.CollaboratorDTOs;
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
        Task<CollaboratorGetPersoDto> GetByIdPersoAsync(string id);
        Task<CollaboratorGetDto> GetByIdAsync(string id);
    }
}
