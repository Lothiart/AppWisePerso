using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.DTOs.CarpoolDTOs;

namespace DriveWise.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CarpoolController(ICarpoolRepository carpoolRepository) : ControllerBase
{
    /// <summary>
    /// Add a carpool - VERIFIER
    /// </summary>
    /// <param name="carpoolAddDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<ActionResult<CarpoolAddDto>> Add(CarpoolAddDto carpoolAddDto)
    {
        try
        {
            await carpoolRepository.AddAsync(carpoolAddDto);
            return Ok(carpoolAddDto);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Add passenger to existing carpool - VERIFIER
    /// </summary>
    /// <param name="carpoolAddPassengerDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<IActionResult> AddPassenger(CarpoolAddPassengerDto carpoolAddPassengerDto)
    {
        try
        {
            await carpoolRepository.AddPassengerAsync(carpoolAddPassengerDto);
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Delete carpool if it doesn't have passengers - VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete(int id)
    {
        try
        {
            bool isDeleted = await carpoolRepository.DeleteAsync(id);

            return isDeleted ? Ok("Carpool successfully deleted") : Problem();
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get carpool by Id - VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<CarpoolGetDto>> GetById(int id)
    {
        try
        {
            CarpoolGetDto carpoolDto = await carpoolRepository.GetByIdAsync(id);

            return carpoolDto != null ? Ok(carpoolDto) : NotFound();
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get all carpools - VERIFIER
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    //[Authorize(Roles = ROLES.ADMIN)]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<List<CarpoolGetDto>>> GetAll()
    {
        List<CarpoolGetDto> carpoolDtos = await carpoolRepository.GetAllAsync();

        if (carpoolDtos.Count > 0)
            return Ok(carpoolDtos);
        else if (carpoolDtos.Count == 0)
            return Ok("No carpools to display");
        else throw new Exception("Failed to get carpools");
    }

    /// <summary>
    /// Get carpools from search fields : date and cities of departure and destination - VERIFIER
    /// </summary>
    /// <param name="carpoolSearch"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<ActionResult<List<CarpoolGetDto>>> GetByCitiesAndDate(CarpoolSearchDto carpoolSearch)
    {
        List<CarpoolGetDto> carpoolDtos = await carpoolRepository.GetByCitiesAndDateAsync(carpoolSearch);

        if (carpoolDtos.Count > 0)
            return Ok(carpoolDtos);
        else if (carpoolDtos.Count == 0)
            return Ok("No carpools to display");
        else throw new Exception("Failed to get carpools");
    }

    /// <summary>
    /// Update carpool - VERIFER
    /// </summary>
    /// <param name="carpoolDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPut]
    public async Task<ActionResult<bool>> Update(CarpoolUpdateDto carpoolDto)
    {
        try
        {
            bool isUpdated = await carpoolRepository.UpdateAsync(carpoolDto);

            return isUpdated ? Ok("Carpool successfully updated") : Problem();
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get user's carpools where user is driver - VERIFIER
    /// </summary>
    /// <param name="collaboratorId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<List<CarpoolGetDto>>> GetAllAsDriver(int collaboratorId)
    {
        List<CarpoolGetDto> carpoolDtos = await carpoolRepository.GetAllAsDriverAsync(collaboratorId);

        if (carpoolDtos.Count > 0)
            return Ok(carpoolDtos);
        else if (carpoolDtos.Count == 0)
            return Ok("No carpools to display");
        else throw new Exception("Failed to get carpools");
    }

    /// <summary>
    /// Get user's carpools where user is passenger - VERIFIER
    /// </summary>
    /// <param name="collaboratorId"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<List<CarpoolGetDto>>> GetAllAsPassenger(int collaboratorId)
    {
        List<CarpoolGetDto> carpoolDtos = await carpoolRepository.GetAllAsPassengerAsync(collaboratorId);

        if (carpoolDtos.Count > 0)
            return Ok(carpoolDtos);
        else if (carpoolDtos.Count == 0)
            return Ok("No carpools to display");
        else throw new Exception("Failed to get carpools");
    }
}
