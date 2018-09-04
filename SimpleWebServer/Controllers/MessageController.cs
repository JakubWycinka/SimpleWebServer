using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebServer.Models.DtoModels;
using SimpleWebServer.Services.Interfaces;

namespace SimpleWebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ISimpleMessageService simpleMessageService;

        public MessageController(ISimpleMessageService simpleMessageService)
        {
            this.simpleMessageService = simpleMessageService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var messages = await simpleMessageService.GetAll();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var message = await simpleMessageService.Get(id);
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SimpleMessageDto messageDto)
        {
            var message = await simpleMessageService.Add(messageDto);
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await simpleMessageService.Delete(id);
            return Ok();
        }
    }
}
