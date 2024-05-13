using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DriveWise.Controllers;

/// <summary>
/// Test ok
/// </summary>
/// <param name="roleManager"></param>
/// <param name="userManager"></param>

[Route("api/[controller]/[action]")]
[ApiController]
public class RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager) : ControllerBase
{
    [HttpPost]

    [Authorize(Roles = "ADMIN")]

    public async Task<IActionResult> CreateRole(string role)
    {
        IdentityResult result = await roleManager.CreateAsync(new IdentityRole { Name = role, NormalizedName = "ADMIN" });

        return Ok($"The role {role} has been created");
    }
}