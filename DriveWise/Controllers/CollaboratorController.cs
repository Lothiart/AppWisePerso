using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers
{
    public class CollaboratorController(
        ICityRepository cityRepository,
        ILogger<CityController> logger) : ControllerBase
    {
        
    }
}
