using DTOs.DTOs.CollaboratorDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Mappers;
public class CollaboratorMapper
{
    public CollaboratorGetDto CollaboratorToCollaboratorGetDto(Collaborator c)
    {
        CollaboratorGetDto collaboratorDto = new CollaboratorGetDto()
        {
            Id = c.Id,
            AppUser = c.AppUser,
            FirstName = c.FirstName,
            LastName = c.LastName            
        };

        return collaboratorDto;
    }
}
