using Services.DTOs.RentalDTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Entities.Const;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]

public class RentalController(IRentalRepository rentalRepository, UserManager<AppUser> userManager, ILogger<RentalController> logger) : ControllerBase
{


    ///////// ADMIN /////////


    /// <summary>
    /// Get all currents rentals for ADMIN test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllCurrentsAdmin()
    {
        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllCurrentsAdminAsync();

            if (listRentalsDto.Count == 0)
                return NoContent();

            return Ok(listRentalsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all currents rentals");
            throw;
        }
    }


    /// <summary>
    /// Get all pasts rentals for ADMIN test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllPastsAdmin()
    {
        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllPastsAdminAsync();

            if (listRentalsDto.Count == 0)
                return NoContent();

            return Ok(listRentalsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all pasts rentals");
            throw;
        }
    }

    /// <summary>
    /// Get all futures rentals for ADMIN test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize(Roles = "ADMIN")]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllFuturesAdmin()
    {
        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllFuturesAdminAsync();

            if (listRentalsDto.Count == 0)
                return NoContent();

            return Ok(listRentalsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all futures rentals");
            throw;
        }
    }



    ///////// COLLABORATOR /////////



    /// <summary>
    /// Get all currents rentals test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllCurrents()
    {
        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                                .Users
                                .Include(u => u.Collaborator)
                                .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllCurrentsUserAsync(currentUser);

            if (listRentalsDto.Count == 0)
                return NoContent();

            return Ok(listRentalsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all your currents rentals");
            throw;
        }
    }


    /// <summary>
    /// Get all pasts rentals test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllPasts()
    {
        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                         .Users
                         .Include(u => u.Collaborator)
                         .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllPastsUserAsync(currentUser);

            if (listRentalsDto.Count == 0)
                return NoContent();

            return Ok(listRentalsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all your pasts rentals");
            throw;
        }
    }



    /// <summary>
    /// Get all futures rentals test OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(401)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<List<RentalGetDto>>> GetAllFutures()
    {
        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                                .Users
                                .Include(u => u.Collaborator)
                                .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        try
        {
            List<RentalGetDto> listRentalsDto = await rentalRepository.GetAllFuturesUserAsync(currentUser);

            if (listRentalsDto.Count == 0)
                return NoContent();

            return Ok(listRentalsDto);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching all your futures rentals");
            throw;
        }
    }


    /// <summary>
    /// Get one rental by Id A VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    [Authorize]

    public async Task<ActionResult<RentalGetDto>> GetById(int id)
    {

        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                                .Users
                                .Include(u => u.Collaborator)
                                .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            RentalGetDto currentRentalDto = await rentalRepository.GetByIdAsync(id, currentUser);
            return Ok(currentRentalDto);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching your rental by id");
            throw;
        }
    }


    /// <summary>
    /// Create a new rental test OK
    /// </summary>
    /// <param name="rentalAddDto"></param>
    /// <returns></returns>

    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpPost]

    [Authorize]

    public async Task<ActionResult<RentalAddDto>> Add(RentalAddDto rentalAddDto)
    {

        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                                .Users
                                .Include(u => u.Collaborator)
                                .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        if (!(rentalAddDto.CollaboratorId == currentUser.Collaborator.Id || await userManager.IsInRoleAsync(currentUser, ROLES.ADMIN)))
            return Forbid("You can't create rental for someone else ");

        if (rentalAddDto.EndDateId <= rentalAddDto.StartDateId)
            return BadRequest("Ending rental date must be later than starting rental date");

        if (rentalAddDto.StartDateId < DateTime.Now)
            return BadRequest("Sorry, as long as we're not able to time travel, you can't rent vehicles in the past");

        try
        {
            RentalAddDto createdRental = await rentalRepository.AddAsync(rentalAddDto, currentUser);
            return Created($"Your rental has been successfully created and starts on {createdRental.StartDateId.ToLongDateString()} at {createdRental.StartDateId.ToShortTimeString()}", createdRental);
        }
        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while fetching your rental by id");
            throw;
        }
    }


    /// <summary>
    ///  Update a rental test OK
    /// </summary>
    /// <param name="rentalUpdateDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpPut]

    [Authorize]

    public async Task<ActionResult<RentalUpdateDto>> Update(RentalUpdateDto rentalUpdateDto)
    {

        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                                .Users
                                .Include(u => u.Collaborator)
                                .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        if (!(rentalUpdateDto.CollaboratorId == currentUser.Collaborator.Id || await userManager.IsInRoleAsync(currentUser, ROLES.ADMIN)))
            return Forbid("You're not the rental owner, you can't update it");

        if (rentalUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        if (rentalUpdateDto.EndDateId <= rentalUpdateDto.StartDateId)
            return BadRequest("Ending rental date must be later than starting rental date");


        try
        {
            RentalUpdateDto rentalToUpdate = await rentalRepository.UpdateAsync(rentalUpdateDto, currentUser);

            return Ok("Your rental has been successfully updated");
        }

        catch (KeyNotFoundException e)
        {
            logger.LogInformation(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while updating your rental");
            throw;
        }
    }


    /// <summary>
    /// Delete a rental test OK
    /// </summary>
    /// <param name="id"></param>
    /// <param name="collaboratorId"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(401)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    [Authorize]

    public async Task<ActionResult> Delete(int id, int collaboratorId)
    {

        string? currentUserGuid = userManager.GetUserId(User);

        if (currentUserGuid == null)
            return Unauthorized("You have to login");

        AppUser? currentUser = await userManager
                                .Users
                                .Include(u => u.Collaborator)
                                .FirstOrDefaultAsync(a => a.Id == currentUserGuid);

        if (currentUser == null)
            return Unauthorized("You're not properly registered");

        if (!(collaboratorId == currentUser.Collaborator.Id || await userManager.IsInRoleAsync(currentUser, ROLES.ADMIN)))
            return Forbid("You're not the rental owner, you can't update it");

        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            await rentalRepository.DeleteAsync(id, currentUser);
            return Ok($"The rental has been successfully deleted");
        }
        catch (KeyNotFoundException e)
        {
            logger.LogError(e, e.Message);
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            logger.LogError(e, "An unexpected error occurred while deleting the rental");
            throw;
        }
    }
}