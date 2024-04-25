using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.CollaboratorDTOs
{
    public class CollaboratorGetPersoDto : CollaboratorAddDto
    {
        public string Id { get; set; }
        public List<Carpool> CarpoolsAsDriver { get; set; }

        public List<Carpool> CarpoolsAsPassenger { get; set; }
    }
}
