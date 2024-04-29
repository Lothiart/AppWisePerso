using DTOs.DTOs.MotorDTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]


//    [Authorize(Roles = "ADMIN")]
//    [Authorize]

public class MotorController(IMotorRepository motorRepository) : ControllerBase
{

    /// <summary>
    /// Get all motors test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<MotorGetDto>>> GetAllMotors()
    {
        try
        {
            List<MotorGetDto> listMotorsDto = await motorRepository.GetAllAsync();

            return Ok(listMotorsDto);
        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<MotorGetDto>> GetMotorById(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            MotorGetDto oneMotorDto = await motorRepository.GetByIdAsync(id);
            return oneMotorDto == null ? NotFound() : Ok(oneMotorDto);
        }
        catch (Exception)
        {
            throw;
        }
    }



    /// <summary>
    /// Add new motor test OK
    /// </summary>
    /// <param name="motorAddDto"></param>
    /// <returns></returns>
    /// 

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [HttpPost]

    public async Task<ActionResult<MotorAddDto>> AddMotor(MotorAddDto motorAddDto)
    {
        try
        {
            MotorAddDto motor = new MotorAddDto
            {
                Type = motorAddDto.Type,
            };

            motor = await motorRepository.AddAsync(motorAddDto);
            return Ok($"New motor type {motor.Type} has been added");
        }
        catch (Exception)
        {
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
    [ProducesResponseType(500)]

    [HttpPut]

    public async Task<ActionResult<Motor>> UpdateMotor(MotorUpdateDto motorUpdateDto)
    {
        if (motorUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {

            Motor motorToUpdate = await motorRepository.UpdateAsync(motorUpdateDto);

            return motorToUpdate == null ? NotFound() : Ok($"The status has been updated to {motorToUpdate.Type}");

        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    public async Task<ActionResult> DeleteMotor(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            Motor motorToDelete = await motorRepository.DeleteAsync(id);

            return motorToDelete == null ? NotFound() : Ok($"The motor has been successfully deleted");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
