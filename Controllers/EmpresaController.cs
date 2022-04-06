using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepo empresaRepo;
        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllEmpresa()
        {

            var res = empresaRepo.GetAllEmpresas();

            return Ok(res);
        }
    }
}