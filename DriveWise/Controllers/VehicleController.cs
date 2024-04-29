using DTOs.DTOs.VehicleDTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]


public class VehicleController(IVehicleRepository vehicleRepository) : ControllerBase
{

    /// <summary>
    /// Get all vehicles for Admin A VERIFIER
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleAdminDto>>> GetAllAdmin()
    {
        try
        {
            List<VehicleAdminDto> listVehicleDto = await vehicleRepository.GetAllAdminAsync();
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {
            throw;
        }
    }






    /// <summary>
    /// Look for a list of cars to rent by dates A VERIFIER
    /// 
    /// </summary>
    /// <param name="vehicleByDateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByDates(VehicleByDateDto vehicleByDateDto)
    {
        if (vehicleByDateDto.EndDateId <= vehicleByDateDto.StartDateId)
            return BadRequest("Ending rental date must be later than starting rental date");

        try
        {
            List<VehicleGetDto> listVehiclesDto = new List<VehicleGetDto>();

            listVehiclesDto = await vehicleRepository.GetAllByDatesAsync(vehicleByDateDto);

            return Ok(listVehiclesDto);

        }
        catch (Exception)
        {

            throw;
        }
    }


}
