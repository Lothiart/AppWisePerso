using Services.DTOs.MotorDTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class MotorController(IMotorRepository motorRepository, ILogger<MotorController> logger) : ControllerBase
{

    /// <summary>
    /// Get all motors test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<MotorGetDto>>> GetAllMotors()
    {
        try
        {
            List<MotorGetDto> listMotorsDto = await motorRepository.GetAllAsync();

            if (listMotorsDto.Count == 0)
                return NoContent();

            return Ok(listMotorsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all motors");
            throw;
        }
    }


    /// <summary>
    /// Get one motor by Id test OK
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

    public async Task<ActionResult<MotorGetDto>> GetMotorById(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            MotorGetDto oneMotorDto = await motorRepository.GetByIdAsync(id);
            return Ok(oneMotorDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching motor by Id");
            throw;
        }
    }


    /// <summary>
    /// Add new motor test OK
    /// </summary>
    /// <param name="motorAddDto"></param>
    /// <returns></returns>

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(409)]
    [ProducesResponseType(500)]

    [HttpPost]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<MotorAddDto>> AddMotor(MotorAddDto motorAddDto)
    {

        if (string.IsNullOrWhiteSpace(motorAddDto.Type))
            return BadRequest("Motor type can't be null or empty");

        try
        {
            MotorAddDto motorToCreate = await motorRepository.AddAsync(motorAddDto);
            return Created($"New motor type {motorToCreate.Type} has been added", motorToCreate);
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The motor type {motorAddDto.Type} is unique and already exist in database");
            return Conflict($"The motor type {motorAddDto.Type} is unique and already exist in database");
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while adding the motor type");
            throw;
        }
    }


    /// <summary>
    /// Update a motor test OK
    /// </summary>
    /// <param name="motorUpdateDto"></param>
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

    public async Task<ActionResult<Motor>> UpdateMotor(MotorUpdateDto motorUpdateDto)
    {
        if (motorUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        if (string.IsNullOrWhiteSpace(motorUpdateDto.Type))
            return BadRequest("Motor type can't be null or empty");

        try
        {
            MotorUpdateDto motorToUpdate = await motorRepository.UpdateAsync(motorUpdateDto);
            return Ok($"The status has been updated to {motorToUpdate.Type}");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (DbUpdateException e)
        {
            logger.LogError(e, $"The motor type {motorUpdateDto.Type} is unique and already exist in database");
            return Conflict($"The motor type {motorUpdateDto.Type} is unique and already exist in database");
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating the motor type");
            throw;
        }
    }


    /// <summary>
    /// Delete a motor test OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// 

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult> DeleteMotor(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            await motorRepository.DeleteAsync(id);
            return Ok($"The motor has been successfully deleted");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the motor type");
            throw;
        }
    }
}
