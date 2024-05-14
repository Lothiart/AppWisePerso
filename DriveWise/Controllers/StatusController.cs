using Services.DTOs.StatusDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]

[ApiController]

[Authorize(Roles = "ADMIN")]

public class StatusController(IStatusRepository statusRepository, ILogger<StatusController> logger) : ControllerBase
{

    /// <summary>
    /// Get all statuses test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<StatusGetDto>>> GetAllStatuses()
    {
        try
        {
            List<StatusGetDto> listStatusesDTO = await statusRepository.GetAllAsync();

            if (listStatusesDTO.Count == 0)
                return NoContent();

            return Ok(listStatusesDTO);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all statuses");
            throw;
        }
    }


    /// <summary>
    /// Get one status by Id test OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<StatusGetDto>> GetStatusById(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            StatusGetDto statusGetDto = await statusRepository.GetByIdAsync(id);
            return Ok(statusGetDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching status by Id");
            throw;
        }
    }


    /// <summary>
    /// Create a new status by giving it a name test OK
    /// </summary>
    /// <param name="statusAddDto"></param>
    /// <returns></returns>

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<StatusAddDto>> AddStatus(StatusAddDto statusAddDto)
    {

        if (string.IsNullOrWhiteSpace(statusAddDto.Name))
            return BadRequest("Status name can't be null or empty");

        try
        {
            StatusAddDto statusToCreate = await statusRepository.AddAsync(statusAddDto);
            return Created($"New status {statusToCreate.Name} has been created", statusToCreate);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while adding the status name");
            throw;
        }
    }


    /// <summary>
    /// Update a Status test OK
    /// </summary>
    /// <param name="statusUpdateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpPut]

    public async Task<ActionResult<StatusUpdateDto>> UpdateStatus(StatusUpdateDto statusUpdateDto)
    {
        if (statusUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        if (string.IsNullOrWhiteSpace(statusUpdateDto.Name))
            return BadRequest("Status name can't be null or empty");

        try
        {
            StatusUpdateDto statusToUpdate = await statusRepository.UpdateAsync(statusUpdateDto);
            return Ok($"The status has been updated to {statusToUpdate.Name}");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating the status name");
            throw;
        }
    }


    /// <summary>
    /// Delete a status test OK
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

    public async Task<ActionResult> DeleteStatus(int id)
    {

        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            await statusRepository.DeleteAsync(id);
            return Ok($"The status has been successfully deleted");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the status name");
            throw;
        }
    }
}