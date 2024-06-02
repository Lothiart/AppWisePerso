using Services.DTOs.ModelDTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.DTOs.BrandDTOs;

namespace DriveWise.Controllers;

[Route("api/[controller]/[action]")]

[ApiController]

public class ModelController(
    IModelRepository modelRepository,
    ILogger<ModelController> logger) : ControllerBase
{
    /// <summary>
    /// Add model - VERIFIER
    /// </summary>
    /// <param name="modelAddDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Add(ModelAddDto modelAddDto)
    {
        try
        {
            await modelRepository.AddAsync(modelAddDto);

            return Ok(modelAddDto);
        }
        catch (Exception e)
        {
            return Problem(e!.InnerException!.Message);
        }
    }

    /// <summary>
    /// Get model by id VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            return Ok(await modelRepository.GetByIdAsync(id));
        }
        catch (Exception e)
        {
            return Problem(e!.InnerException!.Message);
        }
    }

    /// <summary>
    /// Get all models VERIFIER
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            return Ok(await modelRepository.GetAllAsync());
        }
        catch (Exception e)
        {
            return Problem(e!.InnerException!.Message);
        }
    }

    /// <summary>
    /// Update model - VERIFIER
    /// </summary>
    /// <param name="modelUpdateDto"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update(ModelUpdateDto modelUpdateDto)
    {
        try
        {
            await modelRepository.UpdateAsync(modelUpdateDto);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e!.InnerException!.Message);
        }
    }

    /// <summary>
    /// Delete model - VERIFIER
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await modelRepository.DeleteAsync(id);
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(e!.InnerException!.Message);
        }
    }
    /// <summary>
    /// Get models by search VERIFIER
    /// </summary>
    /// <param name="brand"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetByBrand(int id)
    {
        try
        {  
           
            return Ok(await modelRepository.GetByBrandAsync(id));
        }
        catch (Exception e)
        {
            return Problem(e!.InnerException!.Message);
        }
    }
}
