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
    public class ServicoRepo : IServicoRepo
    {
        public async Task<List<ServicoRes>> GetAllServisos()
        {
            using var context = new ApiContext();
            try
            {
                var servicos = await context.Servicos
                .GroupJoin(
                  context.Usuarios,
                  i => i.DonoServico,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ServicoRes
                 {
                     Id = temp.i.Id,
                     Desconto = temp.i.Desconto,
                     Descricao = temp.i.Descricao,
                     IdDonoServico = p.Id,
                     Tipo = temp.i.Tipo,
                     NomeDonoServico = p.Nome,
                     Telefone1 = temp.i.Telefone1,
                     Telefone2 = temp.i.Telefone2,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Nome = temp.i.Nome,
                     Img = ""
                 }).ToListAsync();

                return servicos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<ServicoRes> GetServicoById(int id)
        {
            using var context = new ApiContext();

            var servico = await context.Servicos.Where(x => x.Id == id)
                .GroupJoin(
                  context.Usuarios,
                  i => i.DonoServico,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ServicoRes
                 {
                     Id = temp.i.Id,
                     Desconto = temp.i.Desconto,
                     Descricao = temp.i.Descricao,
                     IdDonoServico = p.Id,
                     Tipo = temp.i.Tipo,
                     NomeDonoServico = p.Nome,
                     Telefone1 = temp.i.Telefone1,
                     Telefone2 = temp.i.Telefone2,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Nome = temp.i.Nome,
                     Img = ""
                 }).FirstOrDefaultAsync();

            return servico;
        }

        public async Task<List<ServicoRes>> GetServicoByUsuario(int id)
        {
            using var context = new ApiContext();

            var servicoS = await context.Servicos.Where(x => x.DonoServico == id)
                .GroupJoin(
                  context.Usuarios,
                  i => i.DonoServico,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ServicoRes
                 {
                     Id = temp.i.Id,
                     Desconto = temp.i.Desconto,
                     Descricao = temp.i.Descricao,
                     IdDonoServico = p.Id,
                     Tipo = temp.i.Tipo,
                     NomeDonoServico = p.Nome,
                     Telefone1 = temp.i.Telefone1,
                     Telefone2 = temp.i.Telefone2,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Nome = temp.i.Nome,
                     Img = ""
                 }).ToListAsync();

            return servicoS;
        }

        public async Task<List<ServicoRes>> GetServicoByTipo(string tipo)
        {
            using var context = new ApiContext();

            var servicos = await context.Servicos.Where(x => x.Tipo == tipo)
                .GroupJoin(
                  context.Usuarios,
                  i => i.DonoServico,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ServicoRes
                 {
                     Id = temp.i.Id,
                     Desconto = temp.i.Desconto,
                     Descricao = temp.i.Descricao,
                     IdDonoServico = p.Id,
                     Tipo = temp.i.Tipo,
                     NomeDonoServico = p.Nome,
                     Telefone1 = temp.i.Telefone1,
                     Telefone2 = temp.i.Telefone2,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Imagem = context.Arquivos.Where(x => x.Guid ==  temp.i.IdImagem).FirstOrDefault(),
                     Nome = temp.i.Nome,
                 }).ToListAsync();

            return servicos;
        }

        public async Task PostServico(ServicoReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var servico = new Servico()
                {
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Descricao = rq.Descricao,
                    Rua = rq.Rua,
                    Bairro = rq.Bairro,
                    Cidade = rq.Cidade,
                    Nome = rq.Nome,
                    Tipo = rq.Tipo,
                    IdImagem = guid,
                    DonoServico = rq.DonoServico,
                    Desconto = rq.Desconto,
                    Telefone1 = rq.Telefone1,
                    Telefone2 = rq.Telefone2
                };

                var imagem = new Arquivo()
                {
                    Guid = guid,
                    Nome = rq.Imagem.Nome,
                    Tipo = rq.Imagem.Tipo,
                    Dados = rq.Imagem.Dados,
                };

                await context.Servicos.AddAsync(servico);
                await context.Arquivos.AddAsync(imagem);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateServico(ServicoReq rq)
        {
            using var context = new ApiContext();

            var guid = Guid.NewGuid().ToString().Replace("-", "");

            var servico = new Servico()
            {
                Id = rq.Id,
                DataAtualizacao = DateTime.Now,
                DataCriacao = rq.DataCriacao,
                Descricao = rq.Descricao,
                Rua = rq.Rua,
                Bairro = rq.Bairro,
                Cidade = rq.Cidade,
                Nome = rq.Nome,
                Tipo = rq.Tipo,
                IdImagem = guid,
                DonoServico = rq.DonoServico,
                Desconto = rq.Desconto,
                Telefone1 = rq.Telefone1,
                Telefone2 = rq.Telefone2
            };

            var imagem = new Arquivo()
            {
                Id = rq.Imagem.Id,
                Guid = guid,
                Nome = rq.Imagem.Nome,
                Tipo = rq.Imagem.Tipo,
                Dados = rq.Imagem.Dados,
            };

            context.Servicos.Update(servico);
            context.Arquivos.Update(imagem);

            await context.SaveChangesAsync();
        }

        public async Task DeleteServico(int id)
        {
            using var context = new ApiContext();

            try
            {
                var servico = await context.Servicos.Where(x => x.Id == id).FirstOrDefaultAsync();
                var imagemServico = await context.Arquivos.Where(x => x.Guid == servico.IdImagem).FirstOrDefaultAsync();
                var produto = await context.Produtos.Where(x => x.IdServico == servico.Id).ToListAsync();
                if (produto.Count() != 0)
                {
                    var idImagemProduto = produto.Select(x => x.IdImagem).ToList();
                    context.Produtos.RemoveRange(produto);
                    var imagemProduto = await context.Arquivos.Where(x => idImagemProduto.Contains(x.Guid)).ToListAsync();
                    if(imagemProduto.Count() != 0)
                    {
                        context.Arquivos.RemoveRange(imagemProduto);
                    }
                }                

                context.Servicos.Remove(servico);    
                
                if(imagemServico != null)
                    context.Arquivos.Remove(imagemServico);
                

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
