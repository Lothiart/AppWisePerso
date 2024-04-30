using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.DTOs.CarpoolDTOs;

namespace DriveWise.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class CarpoolController(ICarpoolRepository carpoolRepository) : ControllerBase
{
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

    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<IActionResult> AddPassenger(int carpoolId, int collaboratorId)
    {
        try
        {
            await carpoolRepository.AddPassengerAsync(carpoolId, collaboratorId);
            return Ok();
        }
        catch (Exception)
        {
            throw;
        }
    }

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


    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<List<CarpoolGetDto>>> GetByUserAndDateAsc(int userId)
    {
        List<CarpoolGetDto> carpoolDtos = await carpoolRepository.GetByUserAndDateAscAsync(userId);

        if (carpoolDtos.Count > 0)
            return Ok(carpoolDtos);
        else if (carpoolDtos.Count == 0)
            return Ok("No carpools to display");
        else throw new Exception("Failed to get carpools");
    }


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
}
