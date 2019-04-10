using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.API.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected ActionResult ReturnBadRequest()
        {
            return BadRequest(new
            {
                Success = false,
                Message = "Invalid data!"
            });
        }
    }
}
