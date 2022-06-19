using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Chat;
using Api.Domain;
using Api.Domain.Entities;
using Api.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatRepo _chatRepo;

        public ChatController(IHubContext<ChatHub> hubContext, IChatRepo chatRepo)
        {
            _hubContext = hubContext;
            _chatRepo = chatRepo;
        }

        [Route("send")]
        [HttpPost]
        public IActionResult SendRequest(MessageDto msg)
        {
            _hubContext.Clients.All.SendAsync("ReceiveMessage1", msg.User, msg.Menssagem);
            return Ok();
        }

        [Route("SendGroup")]
        [HttpPost]
        public IActionResult SendGroup(MessageDto msg)
        {

            var res = _hubContext.Clients.Users(msg.Destinatario).SendAsync("ReceiveMessage", msg.User, msg.Menssagem);
            return Ok(res);
        }


        [HttpPost]
        [Authorize]
        [Route("GetChatById")]
        public async Task<IActionResult> GetChatById(int id)
        {
            try
            {
                var res = await _chatRepo.GetChatById(id);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("PostChat")]
        public async Task<IActionResult> PostChat(ChatReq rq)
        {
            try
            {
                await _chatRepo.PostChat(rq);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteChat")]
        public async Task<IActionResult> DeleteChat(int id)
        {
            try
            {
                await _chatRepo.DeleteChat(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
