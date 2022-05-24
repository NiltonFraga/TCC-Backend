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
    public class ServicoController : ControllerBase
    {
        private readonly IServicoRepo _servicoRepo;
        private readonly ILogger<ServicoController> _logger;

        public ServicoController(ILogger<ServicoController> logger, IServicoRepo servicoRepo)
        {
            _logger = logger;
            _servicoRepo = servicoRepo;
        }

        [HttpPost]
        [Authorize]
        [Route("GetAllServico")]
        public async Task<IActionResult> GetAllServico()
        {
            var res = await _servicoRepo.GetAllServisos();

            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("GetServicoById")]
        public async Task<IActionResult> GetServicoById(string id)
        {
            try
            {
                int ids = Int32.Parse(id);
                var res = await _servicoRepo.GetServicoById(ids);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Authorize]
        [Route("GetServicoByUsuario")]
        public async Task<IActionResult> GetServicoByUsuario(string id)
        {
            try
            {
                int ids = Int32.Parse(id);
                var res = await _servicoRepo.GetServicoByUsuario(ids);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("GetServicoByTipo")]
        public async Task<IActionResult> GetServicoByTipo(string tipo)
        {
            try
            {
                var res = await _servicoRepo.GetServicoByTipo(tipo);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("PostServico")]
        public async Task<IActionResult> PostServico(ServicoReq rq)
        {
            await _servicoRepo.PostServico(rq);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateServico")]
        public async Task<IActionResult> UpdateServico(ServicoReq rq)
        {
            await _servicoRepo.UpdateServico(rq);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteServico")]
        public async Task<IActionResult> DeleteServico(int id)
        {
            await _servicoRepo.DeleteServico(id);

            return Ok();
        }
    }
}
