using Services.DTOs.AddressDTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class AddressController(IAddressRepository addressRepository) : ControllerBase
{
    /// <summary>
    /// Add an address (with city id) - VERIFIER
    /// </summary>
    /// <param name="addressDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<ActionResult<AddressAddDto>> Add(AddressAddDto addressDto)
    {
        try
        {
            await addressRepository.AddAsync(addressDto);
            return Ok("Address added");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get address by id - VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<AddressGetDto>> GetById(int id)
    {
        try
        {
            AddressGetDto addressDto = await addressRepository.GetByIdAsync(id);
            return addressDto == null ? NotFound("Address not found") : Ok(addressDto);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Provide address id to delete it - VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Address? address = await addressRepository.DeleteAsync(id);
            return address == null ? NotFound("Address not found") : Ok("Address deleted");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Update address (including city id) - VERIFIER
    /// </summary>
    /// <param name="addressDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpPut]
    public async Task<IActionResult> Update(AddressUpdateDto addressDto)
    {
        try
        {
            AddressUpdateDto addressToUpdate = await addressRepository.UpdateAsync(addressDto);

            return addressToUpdate == null ? NotFound("Address not found") : Ok("Address updated");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
