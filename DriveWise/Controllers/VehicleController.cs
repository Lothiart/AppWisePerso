using Services.DTOs.VehicleDTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]


public class VehicleController(IVehicleRepository vehicleRepository, ILogger<MotorController> logger) : ControllerBase
{


    ///////////  Admin  ///////////

    #region Admin


    /// <summary>
    /// Get all vehicles for Admin TEST OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]


    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllAdmin()
    {
        try
        {
            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllAdminAsync();

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by brand's id for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByBrandIdAdmin(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByBrandIdAdminAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by brand's Id");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by category's id for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByCategoryIdAdmin(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByCategoryIdAdminAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by category's Id");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by motor's id for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByMotorIdAdmin(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByMotorIdAdminAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by motor's Id");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by status id for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByStatusIdAdmin(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByMotorIdAdminAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by status Id");
            throw;
        }
    }


    /// <summary>
    /// Get a vehicle by Id for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<VehicleAdminDto>>> GetByIdAdmin(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            VehicleAdminDto listVehicleDto = await vehicleRepository.GetByIdAdminAsync(id);
            return Ok(listVehicleDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching vehicle by Id");
            throw;
        }
    }


    /// <summary>
    /// Create a new vehicle for Admin TEST OK
    /// </summary>
    /// <param name="vehicleAdminDto"></param>
    /// <returns></returns>

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]

    [HttpPost]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<VehicleAdminDto>> Add(VehicleAdminDto vehicleAdminDto)
    {

        if (string.IsNullOrWhiteSpace(vehicleAdminDto.Registration))
            return BadRequest("Vehicle's registration can't be null or empty");

        try
        {
            VehicleAdminDto vehicleToCreate = await vehicleRepository.AddAdminAsync(vehicleAdminDto);
            return Created($"Your vehicle has been successfully added", vehicleToCreate);
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The vehicle's registration {vehicleAdminDto.Registration} is unique and already exist in database");
            return Conflict($"The vehicle's registration {vehicleAdminDto.Registration} is unique and already exist in database");
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while adding the vehicule");
            throw;
        }
    }


    /// <summary>
    ///  Update a vehicle for Admin TEST OK
    /// </summary>
    /// <param name="vehicleUpdateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]

    [HttpPut]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<VehicleUpdateDto>> Update(VehicleUpdateDto vehicleUpdateDto)
    {
        if (vehicleUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        if (string.IsNullOrWhiteSpace(vehicleUpdateDto.Registration))
            return BadRequest("Vehicle's registration can't be null or empty");

        try
        {
            VehicleUpdateDto vehicleToUpdate = await vehicleRepository.UpdateAdminAsync(vehicleUpdateDto);
            return Ok("Your vehicle has been successfully updated");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The vehicle's registration {vehicleUpdateDto.Registration} is unique and already exist in database");
            return Conflict($"The vehicle's registration {vehicleUpdateDto.Registration} is unique and already exist in database");
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating the vehicule");
            throw;
        }
    }


    /// <summary>
    /// Delete a vehicle for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            await vehicleRepository.DeleteAdminAsync(id);
            return Ok($"The vehicle has been successfully deleted");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the vehicle");
            throw;
        }
    }


    #endregion


    ///////////  Collaborator  ///////////


    #region Collaborator


    /// <summary>
    /// Look for a list of cars to rent by dates TEST OK
    /// </summary>
    /// <param name="vehicleByDateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpPost]

    [Authorize]


    public async Task<ActionResult<List<VehicleRentalDto>>> GetAllByDates(VehicleByDateDto vehicleByDateDto)
    {
        if (vehicleByDateDto.EndDateId <= vehicleByDateDto.StartDateId)
            return BadRequest("Ending rental date must be later than starting rental date");

        try
        {
            List<VehicleRentalDto> listVehiclesDto = await vehicleRepository.GetAllByDatesAsync(vehicleByDateDto);

            if (listVehiclesDto.Count == 0)
                return NoContent();

            return Ok(listVehiclesDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching available vehicles");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by brand's id TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByBrandId(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetDto> listVehicleDto = await vehicleRepository.GetAllByBrandIdAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by brand's Id");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by category's id TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByCategoryId(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetDto> listVehicleDto = await vehicleRepository.GetAllByCategoryIdAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by category's Id");
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by motor's id TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByMotorId(int id)
    {
        try
        {
            if (id <= 0)
                return BadRequest("\"Id\" must be a positive number");

            List<VehicleGetDto> listVehicleDto = await vehicleRepository.GetAllByMotorIdAsync(id);

            if (listVehicleDto.Count == 0)
                return NoContent();

            return Ok(listVehicleDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all vehicles by motor's Id");
            throw;
        }
    }

    /// <summary>
    /// Get a vehicle by Id TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<VehicleGetDto>>> GetById(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            VehicleGetDto listVehicleDto = await vehicleRepository.GetByIdAsync(id);
            return Ok(listVehicleDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching vehicle by Id");
            throw;
        }
    }


    #endregion
}
