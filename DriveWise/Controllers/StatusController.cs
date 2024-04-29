using Services.DTOs.StatusDTOs;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]


//    [Authorize(Roles = "ADMIN")]
//    [Authorize]


public class StatusController(IStatusRepository statusRepository) : ControllerBase
{
    /// <summary>
    /// Get all statuses test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]
    public async Task<ActionResult<List<StatusGetDto>>> GetAllStatuses()
    {
        try
        {
            List<StatusGetDto> listStatusesDTO = await statusRepository.GetAllAsync();
            return listStatusesDTO == null ? NotFound() : Ok(listStatusesDTO);
        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet]

    public async Task<ActionResult<StatusGetDto>> GetStatusById(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            StatusGetDto statusGetDtostatus = await statusRepository.GetByIdAsync(id);
            return statusGetDtostatus == null ? NotFound() : Ok(statusGetDtostatus);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Create a new status by giving it a name test OK
    /// </summary>
    /// <param name="statusAddDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]
    public async Task<ActionResult<StatusAddDto>> AddStatus(StatusAddDto statusAddDto)
    {

        try
        {
            StatusAddDto statusToCreate = await statusRepository.AddAsync(statusAddDto);
            return Ok($"New status {statusToCreate.Name} has been created");
        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpPut]

    public async Task<ActionResult<Status>> UpdateStatus(StatusUpdateDto statusUpdateDto)
    {
        if (statusUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            Status statusToUpdate = await statusRepository.UpdateAsync(statusUpdateDto);
            return statusToUpdate == null ? NotFound() : Ok($"The status has been updated to {statusToUpdate.Name}");
        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    public async Task<ActionResult> DeleteStatus(int id)
    {

        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            Status statusToDelete = await statusRepository.DeleteAsync(id);
            return statusToDelete == null ? NotFound() : Ok($"The status has been successfully deleted");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
