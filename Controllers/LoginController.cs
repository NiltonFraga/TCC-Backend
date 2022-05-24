using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Domain.Request;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepo _loginRepo;
        private readonly ILogger<UsuarioController> _logger;

        public LoginController(ILogger<UsuarioController> logger, ILoginRepo loginRepo)
        {
            _logger = logger;
            _loginRepo = loginRepo;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Authenticate(string usuario, string senha)
        {
            try
            {
                var user = await _loginRepo.Login(usuario, senha);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("ValidateToken")]
        public IActionResult ValidateToken(string token)
        {
            try{
                var valido = _loginRepo.ValidateToken(token);

                if (valido)
                    return Ok();
                else
                    return BadRequest("Token Invalido!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<ActionResult<dynamic>> UpdatePassword(string email, string senha)
        {
            await _loginRepo.UpdatePassword(email, senha);

            return Ok();
        }

        [HttpPost]
        [Route("CriarUsuario")]
        public async Task<IActionResult> PostUsuario(UsuarioReq rq)
        {
            try
            {
                var login = await _loginRepo.CriarUsuario(rq);

                return Ok(login);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
