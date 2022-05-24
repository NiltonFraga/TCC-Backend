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
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                 }).ToListAsync();

            return servicos;
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
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                 }).FirstOrDefaultAsync();

            return servico;
        }

        public async Task<ServicoRes> GetServicoByUsuario(int id)
        {
            using var context = new ApiContext();

            var servico = await context.Servicos.Where(x => x.DonoServico == id)
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
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                 }).FirstOrDefaultAsync();

            return servico;
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
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                 }).ToListAsync();

            return servicos;
        }

        public async Task PostServico(ServicoReq rq)
        {
            using var context = new ApiContext();

            try
            {
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
                    Foto = rq.Foto,
                    DonoServico = rq.DonoServico,
                    Desconto = rq.Desconto,
                    Telefone1 = rq.Telefone1,
                    Telefone2 = rq.Telefone2
                };

                await context.Servicos.AddAsync(servico);

                await context.SaveChangesAsync();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec);
            }
        }

        public async Task UpdateServico(ServicoReq rq)
        {
            using var context = new ApiContext();

            var servico = new Servico()
            {
                DataAtualizacao = DateTime.Now,
                DataCriacao = rq.DataCriacao,
                Descricao = rq.Descricao,
                Rua = rq.Rua,
                Bairro = rq.Bairro,
                Cidade = rq.Cidade,
                Nome = rq.Nome,
                Tipo = rq.Tipo,
                Foto = rq.Foto,
                DonoServico = rq.DonoServico,
                Desconto = rq.Desconto,
                Telefone1 = rq.Telefone1,
                Telefone2 = rq.Telefone2
            };

            context.Servicos.Update(servico);

            await context.SaveChangesAsync();
        }

        public async Task DeleteServico(int id)
        {
            using var context = new ApiContext();

            var servico = await context.Servicos.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Servicos.Remove(servico);

            await context.SaveChangesAsync();
        }
    }
}
