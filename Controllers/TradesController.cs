using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PortfolioService.Data;
using PortfolioService.Dtos;
using PortfolioService.Models;

namespace PortfolioService.Controllers
{
    [Route("api/p/[controller]")]
    [ApiController]
    public class TradesController : ControllerBase
    {
        public TradesController()
        {

        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("Inbound POST from trading service");

            return Ok("POST from trading service was received");
        }
    }
}