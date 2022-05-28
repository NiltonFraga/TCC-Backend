using Api.Apllication.Interfaces.Domain;
using Api.Domain.Entities;
using Api.Domain.Request;
using Api.Domain.Response;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Repository.Domain
{
    public class ProdutoRepo : IProdutoRepo
    {
        public async Task<List<ProdutoRes>> GetAllProdutos()
        {
            using var context = new ApiContext();
            try
            {
                var produtos = await context.Produtos
                .GroupJoin(
                  context.Servicos,
                  i => i.IdServico,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ProdutoRes
                 {
                     Id = temp.i.Id,
                     IdServico = p.Id,
                     Url = temp.i.Url,
                     ValorDesconto = temp.i.ValorDesconto,
                     ValorReal = temp.i.ValorReal,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Nome = temp.i.Nome,
                     Img = ""
                 }).ToListAsync();

                return produtos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<List<ProdutoRes>> GetProdutosByServico(int id)
        {
            using var context = new ApiContext();

            try
            {
                var produtos = await context.Produtos
               .Where(x => x.IdServico == id)
               .GroupJoin(
                 context.Servicos,
                 i => i.IdServico,
                 p => p.Id,
                 (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                 (temp, p) =>
                new ProdutoRes
                {
                    Id = temp.i.Id,
                    IdServico = p.Id,
                    Url = temp.i.Url,
                    ValorDesconto = temp.i.ValorDesconto,
                    ValorReal = temp.i.ValorReal,
                    Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                    Nome = temp.i.Nome,
                    Img = ""
                }).ToListAsync();

                return produtos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
           
        }

        public async Task<ProdutoRes> GetProdutosById(int id)
        {
            using var context = new ApiContext();

            try
            {
                var produto = await context.Produtos.Where(x => x.Id == id)
                .GroupJoin(
                  context.Servicos,
                  i => i.IdServico,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ProdutoRes
                 {
                     Id = temp.i.Id,
                     IdServico = p.Id,
                     Url = temp.i.Url,
                     ValorDesconto = temp.i.ValorDesconto,
                     ValorReal = temp.i.ValorReal,
                     IdDonoProduto = temp.i.IdDonoProduto,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Nome = temp.i.Nome,
                     Img = ""
                 }).FirstOrDefaultAsync();

                return produto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        } 

        public async Task PostProduto(ProdutoReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var produto = new Produto()
                {
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Nome = rq.Nome,
                    IdImagem = guid,
                    IdDonoProduto = rq.IdDonoProduto,
                    IdServico = rq.IdServico,
                    Url = rq.Url,
                    ValorDesconto = rq.ValorDesconto,
                    ValorReal = rq.ValorReal
                };

                var imagem = new Arquivo()
                {
                    Guid = guid,
                    Nome = rq.Imagem.Nome,
                    Tipo = rq.Imagem.Tipo,
                    Dados = rq.Imagem.Dados,
                };

                await context.Produtos.AddAsync(produto);
                await context.Arquivos.AddAsync(imagem);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateProduto(ProdutoReq rq)
        {
            using var context = new ApiContext();
            try
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var produto = new Produto()
                {
                    DataAtualizacao = DateTime.Now,
                    Nome = rq.Nome,
                    IdImagem = guid,
                    IdDonoProduto = rq.IdDonoProduto,
                    IdServico = rq.IdServico,
                    Url = rq.Url,
                    ValorDesconto = rq.ValorDesconto,
                    ValorReal = rq.ValorReal,
                    Id = rq.Id
                };

                var imagem = new Arquivo()
                {
                    Id = rq.Imagem.Id,
                    Guid = guid,
                    Nome = rq.Imagem.Nome,
                    Tipo = rq.Imagem.Tipo,
                    Dados = rq.Imagem.Dados,
                };

                context.Produtos.Update(produto);
                context.Arquivos.Update(imagem);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public async Task DeleteProduto(int id)
        {
            using var context = new ApiContext();

            try
            {
                var produto = await context.Produtos.Where(x => x.Id == id).FirstOrDefaultAsync();
                var imagem = await context.Arquivos.Where(x => x.Guid == produto.IdImagem).FirstOrDefaultAsync();

                context.Produtos.Remove(produto);
                context.Arquivos.Remove(imagem);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
    }
}
