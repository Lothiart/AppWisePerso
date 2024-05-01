using Services.DTOs.CollaboratorDTOs;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Entities;
using Microsoft.AspNetCore.Identity;
using Entities.Const;


namespace DriveWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CollaboratorController(
        ICollaboratorRepository collaboratorRepository,
        UserManager<AppUser> userManager,
        ILogger<CollaboratorController> logger) : ControllerBase
    {



        /// <summary>
        /// Register a new appUser and collaborator with Collaborator role . DO NOT USE IDENTITY REGISTER METHOD test ok
        /// </summary>
        /// <param name="createCollaboratorDto"></param>
        /// <returns></returns>
        /// 

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<CreateCollaboratorDto>> CreateAuthor(CreateCollaboratorDto createCollaboratorDto)
        {

            AppUser appUser = new AppUser
            {
                UserName = createCollaboratorDto.Email,
                Email = createCollaboratorDto.Email
            };

            IdentityResult result = await userManager.CreateAsync(appUser, createCollaboratorDto.Password);

            if (result.Succeeded)
            {
                try
                {
                    Collaborator newCollaborator = await collaboratorRepository.AddAsync(new Collaborator
                    {
                        FirstName = createCollaboratorDto.FirstName,
                        LastName = createCollaboratorDto.LastName,
                        AppUserId = appUser.Id,
                    });

                    await userManager.AddToRoleAsync(appUser, ROLES.COLLABORATOR);
                    return Ok($"Congrats {createCollaboratorDto.FirstName} ! Your account is set up");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
                return Problem(string.Join(" | ", result.Errors.Select(e => e.Description)));
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
