using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
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
        [Route("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var res = await _usuarioRepo.GetAllUsuario();

            return Ok(res);
        }

        [HttpGet]
        [Route("GetUsuario")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var res = await _usuarioRepo.GetUsuario(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("PostUsuario")]
        public async Task<IActionResult> PostUsuariol(Usuario rq)
        {
            await _usuarioRepo.PostUsuario(rq);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(Usuario rq)
        {
            await _usuarioRepo.UpdateUsuario(rq);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUsuario")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuarioRepo.DeleteUsuario(id);

            return Ok();
        }
    }
}
