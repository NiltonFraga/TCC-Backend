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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepo _produtoRepo;
        private readonly ILogger<ProdutoController> _logger;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoRepo produtoRepo)
        {
            _logger = logger;
            _produtoRepo = produtoRepo;
        }

        [HttpPost]
        [Authorize]
        [Route("GetAllProduto")]
        public async Task<IActionResult> GetAllServico()
        {
            try
            {
                var res = await _produtoRepo.GetAllProdutos();

                return Ok(res);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPost]
        [Authorize]
        [Route("GetProdutosByServico")]
        public async Task<IActionResult> GetProdutosByServico(string id)
        {
            try
            {
                int ids = Int32.Parse(id);
                var res = await _produtoRepo.GetProdutosByServico(ids);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Authorize]
        [Route("GetProdutoById")]
        public async Task<IActionResult> GetProdutoById(string id)
        {
            try
            {
                int ids = Int32.Parse(id);
                var res = await _produtoRepo.GetProdutosById(ids);

                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("PostProduto")]
        public async Task<IActionResult> PostProduto(ProdutoReq rq)
        {
            try
            {
                await _produtoRepo.PostProduto(rq);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("UpdateProduto")]
        public async Task<IActionResult> UpdateProduto(ProdutoReq rq)
        {
            await _produtoRepo.UpdateProduto(rq);

            return Ok();
        }

        [HttpPost]
        [Authorize]
        [Route("DeleteProduto")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                await _produtoRepo.DeleteProduto(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }
    }
}
