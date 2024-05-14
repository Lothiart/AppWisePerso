using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.DTOs.DateDTOs;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]

[ApiController]


//    [Authorize(Roles = "ADMIN")]
//    [Authorize]


public class DateController(IDateRepository dateRepository) : ControllerBase
{
    /// <summary>
    /// Get a list of 2 Dates (startDate and EndDate) that define a Rental period USELESS !!!
    /// </summary>
    /// <param name="dateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<List<Date>>> GetByPeriod(DateDto dateDto)
    {
        try
        {
            DateDto ListDate = await dateRepository.GetByPeriodAsync(dateDto);
            return Ok(ListDate);
        }
        catch (Exception)
        {
            throw;
        }
    }


    /// <summary>
    /// Get one Date A verifier (for Carpool) USELESS !!!
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<DateTime>> GetByDate(DateTime dateTime)
    {
        try
        {
            DateTime? currentDateTime = await dateRepository.GetByDateAsync(dateTime);

            return currentDateTime == null ? NotFound() : Ok(currentDateTime);
        }
        catch (Exception)
        {
            throw;
        }
    }


    /// <summary>
    /// Create a new period (Add 2 dates for Rentals) Test ok
    /// </summary>
    /// <param name="dateDto"></param>
    /// <returns></returns>


    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<DateDto>> AddPeriod(DateDto dateDto)
    {
        DateDto dateDtoToCreate = await dateRepository.AddPeriodAsync(dateDto);
        return Ok($" Starting date {dateDtoToCreate.StartDate} and ending date {dateDtoToCreate.EndDate} have been registered");
    }


    /// <summary>
    /// Add a single Date (for Carpool)  Test ok
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<DateTime>> AddDate(DateTime dateTime)
    {
        DateTime dateDtoToCreate = await dateRepository.AddAsync(dateTime);
        return Ok($"Congrats ! Your new Carpool starts {dateDtoToCreate}");
    }
}
