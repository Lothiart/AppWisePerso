using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Entities;


namespace DTOs.CollaboratorDTOs
{
    public class CollaboratorAddDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public AppUser AppUser { get; set; }

    }
}
