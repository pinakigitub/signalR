using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreWithSignalR.Hubs;
using coreWithSignalR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace coreWithSignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public static List<string> Source { get; set; } = new List<string>();
        private IHubContext<ValuesHub> context;
        public MessageController(IHubContext<ValuesHub> hub)
        {
            this.context = hub;
        }
        [HttpPost]
        [Route("PublishMsg")]
        public async Task<IActionResult> PublishMsg([FromBody]Msg obj)
        {
            try
            {
                Source.Add(obj.MSGs);
                await context.Clients.All.SendAsync("Add", obj.MSGs);
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpGet]
        [Route("RemoveMsg")]
        public async Task<IActionResult> RemoveMsg(string msg)
        {
            try
            {
                await context.Clients.All.SendAsync("Delete", msg);
                return Ok();
            }

            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

    }
}