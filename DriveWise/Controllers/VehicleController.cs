using Services.DTOs.VehicleDTOs;
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


    ///////////  Admin  ///////////

    #region Admin


    /// <summary>
    /// Get all vehicles for Admin TEST OK
    /// </summary>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllAdmin()
    {
        try
        {
            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllAdminAsync();
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {
            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by brand name for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByBrandAdmin(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByBrandAdminAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by category name for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByCategoryAdmin(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByCategoryAdminAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by motor type for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByMotorAdmin(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByMotorTypeAdminAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by status name for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetAdminDto>>> GetAllByStatusAdmin(int id)
    {
        try
        {
            List<VehicleGetAdminDto> listVehicleDto = await vehicleRepository.GetAllByStatusNameAdminAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get a vehicle by Id for Admin TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleAdminDto>>> GetByIdAdmin(int id)
    {
        try
        {
            VehicleAdminDto listVehicleDto = await vehicleRepository.GetByIdAdminAsync(id);
            return listVehicleDto == null ? NotFound() : Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Create a new vehicle for Admin TEST OK
    /// </summary>
    /// <param name="vehicleAdminDto"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<VehicleAdminDto>> Add(VehicleAdminDto vehicleAdminDto)
    {
        try
        {
            VehicleAdminDto vehicleToCreate = await vehicleRepository.AddAdminAsync(vehicleAdminDto);

            return Ok($"Your vehicle has been successfully added");
        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpPut]

    public async Task<ActionResult<Vehicle>> Update(VehicleUpdateDto vehicleUpdateDto)
    {
        if (vehicleUpdateDto.Id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            Vehicle vehicleToUpdate = await vehicleRepository.UpdateAdminAsync(vehicleUpdateDto);

            return vehicleToUpdate == null ? NotFound() : Ok("Your vehicle has been successfully updated");
        }
        catch (Exception)
        {
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
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpDelete]

    public async Task<ActionResult> Delete(int id)
    {
        if (id <= 0)
            return BadRequest("\"Id\" must be a positive number");

        try
        {
            Vehicle vehicleToDelete = await vehicleRepository.DeleteAdminAsync(id);

            return vehicleToDelete == null ? NotFound() : Ok($"The vehicle has been successfully deleted");
        }
        catch (Exception)
        {
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
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]

    [HttpPost]

    public async Task<ActionResult<List<VehicleRentalDto>>> GetAllByDates(VehicleByDateDto vehicleByDateDto)
    {
        if (vehicleByDateDto.EndDateId <= vehicleByDateDto.StartDateId)
            return BadRequest("Ending rental date must be later than starting rental date");

        try
        {
            List<VehicleRentalDto> listVehiclesDto = new List<VehicleRentalDto>();

            listVehiclesDto = await vehicleRepository.GetAllByDatesAsync(vehicleByDateDto);

            return Ok(listVehiclesDto);

        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by brand name TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByBrand(int id)
    {
        try
        {
            List<VehicleGetDto> listVehicleDto = await vehicleRepository.GetAllByBrandAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by category name TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByCategory(int id)
    {
        try
        {
            List<VehicleGetDto> listVehicleDto = await vehicleRepository.GetAllByCategoryAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    /// <summary>
    /// Get all vehicles by motor type TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetDto>>> GetAllByMotor(int id)
    {
        try
        {
            List<VehicleGetDto> listVehicleDto = await vehicleRepository.GetAllByMotorTypeAsync(id);
            return Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// Get a vehicle by Id TEST OK
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>

    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]

    [HttpGet]

    public async Task<ActionResult<List<VehicleGetDto>>> GetById(int id)
    {
        try
        {
            VehicleGetDto listVehicleDto = await vehicleRepository.GetByIdAsync(id);
            return listVehicleDto == null ? NotFound() : Ok(listVehicleDto);
        }
        catch (Exception)
        {

            throw;
        }
    }


    #endregion
}
