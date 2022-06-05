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
    public class PostController : ControllerBase
    {
        private readonly IPostRepo _postRepo;
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, IPostRepo postRepo)
        {
            _logger = logger;
            _postRepo = postRepo;
        }

        [HttpPost]
        [Authorize]
        [Route("GetAllPost")]
        public async Task<IActionResult> GetAllPost(PostFiltroReq req)
        {
            try
            {
                var res = await _postRepo.GetAllPost(req);

                return Ok(res);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Authorize]
        [Route("GetPostAndComentarioById")]
        public async Task<IActionResult> GetPostAndComentarioById(int id)
        {
            try
            {
                var res = await _postRepo.GetPostAndComentarioById(id);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Authorize]
        [Route("GetPostById")]
        public async Task<IActionResult> GetPostById(int id)
        {
            try
            {
                var res = await _postRepo.GetPostById(id);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }        

        [HttpPost]
        [Authorize]
        [Route("PostPost")]
        public async Task<IActionResult> PostPost(PostReq rq)
        {
            try
            {
                await _postRepo.PostPost(rq);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("UpdatePost")]
        public async Task<IActionResult> UpdatePost(PostReq rq)
        {
            try
            {
                await _postRepo.UpdatePost(rq);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("DeletePost")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _postRepo.DeletePost(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
