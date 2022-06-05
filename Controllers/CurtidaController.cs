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
    public class CurtidaController : ControllerBase
    {
        private readonly ICurtidaRepo _curtidaRepo;
        private readonly ILogger<CurtidaController> _logger;

        public CurtidaController(ILogger<CurtidaController> logger, ICurtidaRepo curtidaRepo)
        {
            _logger = logger;
            _curtidaRepo = curtidaRepo;
        }
        

        [HttpPost]
        [Authorize]
        [Route("UpdateCurtida")]
        public async Task<IActionResult> UpdateCurtida(CurtidaReq rq)
        {
            try
            {
                await _curtidaRepo.UpdateCurtida(rq);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
