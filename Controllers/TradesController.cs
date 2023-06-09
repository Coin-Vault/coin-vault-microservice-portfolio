using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioService.Controllers
{
    [Route("api/p/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        public TradesController()
        {

        }

        [Authorize]
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("Inbound POST from trading service");

            return Ok("POST from trading service was received");
        }
    }
}