using DTOs.DTOs.RentalDTOs;
using DTOs.DTOs.StatusDTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

//    [Authorize(Roles = "ADMIN")]
//    [Authorize]

public class RentaController(IRentalRepository rentalRepository) : ControllerBase
{

    /// <summary>
    /// Get all rentals A VERIFIER
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet]

    [HttpGet]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllRentals()
    {
        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllAsync();
            return listRentalsDto == null ? NotFound() : Ok(listRentalsDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


}