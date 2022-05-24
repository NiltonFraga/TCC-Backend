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

        [HttpPost]
        [Authorize]
        [Route("GetAllAnimais")]
        public async Task<IActionResult> GetAllAnimais()
        {
            var res = await _animalRepo.GetAllAnimais();

            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("GetAnimal")]
        public async Task<IActionResult> GetAnimal(string id)
        {
            int ids = Int32.Parse(id);
            var res = await _animalRepo.GetAnimal(ids);

            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        [Route("GetAnimaisByUsuario")]
        public async Task<IActionResult> GetAnimaisByUsuario(string id)
        {
            try
            {
                int ids = Int32.Parse(id);
                var res = await _animalRepo.GetAnimalByUsuario(ids);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
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
