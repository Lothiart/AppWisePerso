using DTOs.DTOs.AddressDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AddressController(IAddressRepository addressRepository) : ControllerBase
{
    [HttpPost]   
    public Task<ActionResult<AddressAddDto>> Add(AddressAddDto addressDto)
    {
        
    }
}
