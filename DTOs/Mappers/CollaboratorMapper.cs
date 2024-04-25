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
            FirstName = c.FirstName,
            LastName = c.LastName
        };

        return collaboratorDto;
    }

    public List<CollaboratorGetDto> ListCollaboratorToListCollaboratorGetDto(List<Collaborator> collaborators)
    {
        if (collaborators is null) return null;

        List<CollaboratorGetDto> collaboratorDtos = new();

        foreach (var collaborator in collaborators)
        {
            collaboratorDtos.Add(CollaboratorToCollaboratorGetDto(collaborator));
        }

        return collaboratorDtos;
    }
}
