using DTOs.DTOs.CityDTOs;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System.ComponentModel;

namespace DriveWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController(
        ICityRepository cityRepository,
        ILogger<CityController> logger) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add(CityAddDto cityAddDto)
        {
            try
            {
                await cityRepository.AddAsync(cityAddDto);
                
                return Ok(cityAddDto);
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
                
                return Ok(await cityRepository.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> StartsWith(string recherche)
        {
            try
            {
                List<CityGetDto> listCity =  await cityRepository.StartsWithAsync(recherche);

                return Ok(listCity);
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(CityUpdateDto cityUpdateDto)
        {
            try
            {
                await cityRepository.UpdateAsync(cityUpdateDto);

                return Ok(cityUpdateDto);
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
                await cityRepository.DeleteAsync(id);

                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
    }
}
