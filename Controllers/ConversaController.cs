using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Domain.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversaController : ControllerBase
    {
        private readonly ILogger<ConversaController> _logger;
        private readonly IConversaRepo _conversaRepo;

        public ConversaController(ILogger<ConversaController> logger, IConversaRepo conversaRepo)
        {
            _logger = logger;
            _conversaRepo = conversaRepo;
        }

        [HttpPost]
        [Authorize]
        [Route("GetAllConversas")]
        public async Task<IActionResult> GetAllConversas(ConversaReq rq)
        {
            try
            {
                var result = await _conversaRepo.GetConversas(rq.UsuarioOrigem, rq.UsuarioDestino);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Authorize]
        [Route("GetByDestino")]
        public async Task<IActionResult> GetByDestino(ConversaReq rq)
        {
            try
            {
                var result = await _conversaRepo.GetByDestino(rq.UsuarioOrigem, rq.UsuarioDestino);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("PostConversa")]
        public async Task<IActionResult> PostConversa(ConversaReq rq)
        {
            try
            {
                await _conversaRepo.PostConversa(rq);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateComentario")]
        public async Task<IActionResult> UpdateConversa(ComentarioRep rq)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteComentario")]
        public async Task<IActionResult> DeleteConversa(int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
