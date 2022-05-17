using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
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
    public class AdocaoController : ControllerBase
    {
        private readonly IAdocaoRepo _adocaoRepo;
        private readonly ILogger<AdocaoController> _logger;

        public AdocaoController(ILogger<AdocaoController> logger, IAdocaoRepo adocaoRepo)
        {
            _logger = logger;
            _adocaoRepo = adocaoRepo;
        }
        
        [HttpGet]
        [Authorize]
        [Route("GetAllAdocoes")]
        public async Task<IActionResult> GetAllAdocoes()
        {
            List<Adocao> res = await _adocaoRepo.GetAllAdocoes();

            return Ok(res);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAdocao")]
        public async Task<IActionResult> GetAdocao(int id)
        {
            var res = await _adocaoRepo.GetAdocao(id);

            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("PostAdocao")]
        public async Task<IActionResult> PostAdocao(Adocao rq)
        {
            await _adocaoRepo.PostAdocao(rq);

            return Ok();
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateAdocao")]
        public async Task<IActionResult> UpdateAdocao(Adocao rq)
        {
            await _adocaoRepo.UpdateAdocao(rq);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteAdocao")]
        public async Task<IActionResult> DeleteAdocao(int id)
        {
            await _adocaoRepo.DeleteAdocao(id);

            return Ok();
        }
    }
}
