using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IProdutoRepo
    {
        Task<List<ProdutoRes>> GetAllProdutos();
        Task<List<ProdutoRes>> GetProdutosByServico(int id);
        Task<ProdutoRes> GetProdutosById(int id);
        Task PostProduto(ProdutoReq rq);
        Task UpdateProduto(ProdutoReq rq);
        Task DeleteProduto(int id);
    }
}
