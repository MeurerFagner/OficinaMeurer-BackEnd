using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace OficinaMeurer.API.Controllers
{
    [ApiController]
    public abstract class BaseController: ControllerBase
    {
        [NonAction]
        public BadRequestObjectResult BadRequest(Exception ex)
        {
            var message = ex?.InnerException?.Message ?? ex!.Message;

            return BadRequest(message);
        }
    }
}
