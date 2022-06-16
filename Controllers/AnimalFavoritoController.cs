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
    public class AnimalFavoritoController : ControllerBase
    {
        private readonly IAnimalFavoritoRepo _favoritoRepo;
        private readonly ILogger<AnimalFavoritoController> _logger;

        public AnimalFavoritoController(ILogger<AnimalFavoritoController> logger, IAnimalFavoritoRepo favoritoRepo)
        {
            _logger = logger;
            _favoritoRepo = favoritoRepo;
        }
        

        [HttpPost]
        [Authorize]
        [Route("UpdateAnimalFavorito")]
        public async Task<IActionResult> UpdateAnimalFavorito(AnimalFavoritoReq rq)
        {
            try
            {
                await _favoritoRepo.UpdateAnimalFavorito(rq);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
