using DTOs.DTOs.CityDTOs;
using DTOs.DTOs.ModelDTOs;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;

namespace DriveWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModelController(
        IModelRepository modelRepository,
        ILogger<ModelController> logger) : ControllerBase
    {
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

        [HttpGet]
        public async Task<IActionResult> GetById()
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

        [HttpPost]
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

        [HttpPost]
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

        [HttpGet]
        public async Task<IActionResult> GetByBrand(Brand brand)
        {
            try
            {
                await modelRepository.GetByBrandAsync(brand);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
    }
}
