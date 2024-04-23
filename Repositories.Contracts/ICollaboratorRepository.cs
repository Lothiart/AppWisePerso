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

        CollaboratorGetPersoDto GetByIdPersoAsync(int id);
        CollaboratorGetDto GetByIdAsync(int id);
        Task GiveAdminRoleAsync(int id);
    }
}
