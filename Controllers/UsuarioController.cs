using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Domain.Request;
using Microsoft.AspNetCore.Authorization;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepo _usuarioRepo;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepo usuarioRepo)
        {
            _logger = logger;
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        [Authorize]
        [Route("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var res = await _usuarioRepo.GetAllUsuarios();

            return Ok(res);
        }

        [HttpGet]
        [Authorize]
        [Route("GetUsuario")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var res = await _usuarioRepo.GetUsuario(id);

            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("PostUsuario")]
        public async Task<IActionResult> PostUsuariol(UsuarioReq rq)
        {
            await _usuarioRepo.PostUsuario(rq);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(Usuario rq)
        {
            await _usuarioRepo.UpdateUsuario(rq);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteUsuario")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepo.DeleteUsuario(id);

            return Ok();
        }
    }
}
