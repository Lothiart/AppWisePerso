using Services.DTOs.BrandDTOs;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System.Collections.Generic;

namespace DriveWise.Controllers;
[Route("api/[controller]/[action]")]
[ApiController]
public class BrandController(IBrandRepository brandRepository) : ControllerBase
{
    /// <summary>
    /// Add brand
    /// </summary>
    /// <param name="brandAddDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [HttpPost]
    public async Task<ActionResult<BrandAddDto>> Add(BrandAddDto brandAddDto)
    {
        try
        {
            BrandAddDto brandDto = await brandRepository.AddAsync(brandAddDto);
            return Ok("Brand added");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Delete brand
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpDelete]
    public async Task<ActionResult<Brand>> Delete(int id)
    {
        try
        {
            bool isDeleted = await brandRepository.DeleteAsync(id);
            return isDeleted ? Ok("Brand deleted") : NotFound("Brand not found");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get all brands
    /// </summary>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<List<BrandGetDto>>> GetAll()
    {
        try
        {
            List<BrandGetDto> brandDtos = await brandRepository.GetAllAsync();

            return Ok(brandDtos);
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Get brand by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpGet]
    public async Task<ActionResult<BrandGetDto>> GetById(int id)
    {
        try
        {
            BrandGetDto brandDto = await brandRepository.GetByIdAsync(id);

            return brandDto != null ? Ok(brandDto) : NotFound("Brand not found");
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Update existing brand
    /// </summary>
    /// <param name="brandDto"></param>
    /// <returns></returns>
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    [HttpPut]
    public async Task<ActionResult<BrandUpdateDto>> Update(BrandUpdateDto brandDto)
    {
        try
        {
            Brand brandToUpdate = await brandRepository.UpdateAsync(brandDto);
            return brandToUpdate != null ? Ok(brandDto) : NotFound("Brand not found");
        }
        catch (Exception)
        {
            throw;
        }
    }
}
