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
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepo _animalRepo;
        private readonly ILogger<AnimalController> _logger;

        public AnimalController(ILogger<AnimalController> logger, IAnimalRepo animalRepo)
        {
            _logger = logger;
            _animalRepo = animalRepo;
        }

        [HttpGet]
        [Route("GetAllAnimais")]
        public async Task<IActionResult> GetAllAnimais()
        {
            var res = await _animalRepo.GetAllAnimais();

            return Ok(res);
        }

        [HttpGet]
        [Route("GetAnimal")]
        public async Task<IActionResult> GetAnimal(int id)
        {
            var res = await _animalRepo.GetAnimal(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("PostAnimal")]
        public async Task<IActionResult> PostAnimal(Animal rq)
        {
            await _animalRepo.PostAnimal(rq);

            return Ok();
        }

        [HttpPut]
        [Route("UpdateAnimal")]
        public async Task<IActionResult> UpdateAnimal(Animal rq)
        {
            await _animalRepo.UpdateAnimal(rq);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAnimal")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            await _animalRepo.DeleteAnimal(id);

            return Ok();
        }
    }
}
