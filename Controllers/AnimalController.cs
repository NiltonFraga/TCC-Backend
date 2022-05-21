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
        [Authorize]
        [Route("GetAllAnimais")]
        public async Task<IActionResult> GetAllAnimais()
        {
            var res = await _animalRepo.GetAllAnimais();

            return Ok(res);
        }

        [HttpGet]
        [Authorize]
        [Route("GetAnimal")]
        public async Task<IActionResult> GetAnimal(int id)
        {
            var res = await _animalRepo.GetAnimal(id);

            return Ok(res);
        }

        [HttpPost]
        [Route("PostAnimal")]
        public async Task<IActionResult> PostAnimal(AnimalReq rq)
        {
            await _animalRepo.PostAnimal(rq);

            return Ok();
        }

        [RequestSizeLimit(2147483648)]
        [HttpPost]
        [Route("UploadImageAnimal/{guid}")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file, string guid)
        {
            var resul = await _animalRepo.UploadImageAnimal(file, guid);

            return Ok(resul);
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateAnimal")]
        public async Task<IActionResult> UpdateAnimal(Animal rq)
        {
            await _animalRepo.UpdateAnimal(rq);

            return Ok();
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteAnimal")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            await _animalRepo.DeleteAnimal(id);

            return Ok();
        }
    }
}
