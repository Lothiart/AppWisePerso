using DTOs.DTOs.AddressDTOs;
using DTOs.DTOs.CollaboratorDTOs;
using DTOs.DTOs.RentalDTOs;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs.CarpoolDTOs;
public class CarpoolUpdateDto
{
    public int Id { get; set; }
    public CollaboratorGetDto CollaboratorGetDto { get; set; }
    public List<CollaboratorGetDto> PassengersGetDto { get; set; }
    public int RemainingSeats { get; set; }
    public RentalGetDto RentalGetDto { get; set; }
    public AddressGetDto StartAddressDto { get; set; }
    public AddressGetDto EndAddress { get; set; }
    public DateTime DateId { get; set; }
}
