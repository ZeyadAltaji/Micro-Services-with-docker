using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
                
        }
        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine( "--> InBound Post # Command Services ! " );
            return Ok("InBound test of from Platforms Controler ! ");
        }
    }
}
