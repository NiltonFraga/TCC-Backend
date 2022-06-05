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
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepo _comentarioRepo;
        private readonly ILogger<ComentarioController> _logger;

        public ComentarioController(ILogger<ComentarioController> logger, IComentarioRepo comentarioRepo)
        {
            _logger = logger;
            _comentarioRepo = comentarioRepo;
        }

        [HttpPost]
        [Authorize]
        [Route("GetComentarioById")]
        public async Task<IActionResult> GetComentarioById(int id)
        {
            try
            {
                var res = await _comentarioRepo.GetComentarioById(id);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Authorize]
        [Route("PostComentario")]
        public async Task<IActionResult> PostComentario(ComentarioRep rq)
        {
            try
            {
                await _comentarioRepo.PostComentario(rq);

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
        public async Task<IActionResult> UpdateComentario(ComentarioRep rq)
        {
            try
            {
                await _comentarioRepo.UpdateComentario(rq);

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
        public async Task<IActionResult> DeleteComentario(int id)
        {
            try
            {
                await _comentarioRepo.DeleteComentario(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
