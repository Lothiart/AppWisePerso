using Services.DTOs.CollaboratorDTOs;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CollaboratorController(
        ICollaboratorRepository collaboratorRepository,
        ILogger<CollaboratorController> logger) : ControllerBase
    {

        /// <summary>
        /// Add collaborator and appuser - VERIFIER
        /// </summary>
        /// <param name="collaboratorAddDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Add(CollaboratorAddDto collaboratorAddDto)
        {
            try
            {
                await collaboratorRepository.AddAsync(collaboratorAddDto);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
        /// <summary>
        /// Get collaborator with info by id - A VERIFIER
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetByIdPerso(int id)
        {
            try
            {
                return Ok(await collaboratorRepository.GetFullUserByIdAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }

        /// <summary>
        /// Get collaborator by id - A VERIFIER
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                return Ok(await collaboratorRepository.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
        /// <summary>
        /// Give collaborator admin role - A VERIFIER
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GiveAdminRole(int id)
        {
            try
            {
                await collaboratorRepository.GiveAdminRoleAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return Problem(e!.InnerException!.Message);
            }
        }
    }
}
