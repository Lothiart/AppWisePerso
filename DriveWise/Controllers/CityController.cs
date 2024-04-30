using Services.DTOs.CityDTOs;
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
        /// <summary>
        /// Add city - VERIFIER
        /// </summary>
        /// <param name="cityAddDto"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get city by id - VERIFIER
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get cities by search - A VERIFIER
        /// </summary>
        /// <param name="research"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> StartsWith(string research)
        {
            try
            {
                List<CityGetDto> listCity = await cityRepository.StartsWithAsync(research);

                return Ok(listCity);
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
        /// <summary>
        /// Update city - VERIFIER
        /// </summary>
        /// <param name="cityUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
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

        /// <summary>
        /// Delete city - VERIFIER
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
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
