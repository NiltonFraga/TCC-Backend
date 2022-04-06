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
        [Route("GetAllAdocaos")]
        public async Task<IActionResult> GetAllAdocaos()
        {
            List<Adocao> res = await _adocaoRepo.GetAllAdocao();

            return Ok(res);
        }

        [HttpGet]
        [Route("GetAdocao")]
        public async Task<IActionResult> GetAdocao(int id)
        {
            var res = await _adocaoRepo.GetAdocao(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("PostAdocao")]
        public async Task<IActionResult> PostAdocao(Adocao rq)
        {
            await _adocaoRepo.PostAdocao(rq);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateAdocao")]
        public async Task<IActionResult> UpdateAdocao(Adocao rq)
        {
            await _adocaoRepo.UpdateAdocao(rq);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAdocao")]
        public async Task<IActionResult> DeleteAdocao(int id)
        {
            await _adocaoRepo.DeleteAdocao(id);

            return Ok();
        }
    }
}
