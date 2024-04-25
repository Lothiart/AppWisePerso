using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace DriveWise.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController(
        ICityRepository cityRepository,
        ILogger<CityController> logger) : ControllerBase
    {





    }
}
