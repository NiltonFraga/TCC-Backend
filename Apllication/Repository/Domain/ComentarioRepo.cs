using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Domain.Entities;
using Api.Domain.Request;
using Api.Domain.Response;
using Api.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Repository.Domain
{
    public class ComentarioRepo : IComentarioRepo
    {
        public async Task<ComentarioRes> GetComentarioById(int id)
        {
            using var context = new ApiContext();

            try
            {
                var comentario = await context.Comentarios
                .Where(x => x.Id == id)
                .GroupJoin(
                  context.Usuarios,
                  i => i.Id,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ComentarioRes
                 {
                     Id = temp.i.Id,
                     Conteudo = temp.i.Conteudo,
                     NomeUsuario = p.Nome,
                     IdUsuario = p.Id,
                     IdPost = temp.i.IdUsuario,
                     DataAtualizacao = temp.i.DataAtualizacao ?? DateTime.Now
                 }).FirstOrDefaultAsync();

                return comentario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        public async Task PostComentario(ComentarioRep rq)
        {
            using var context = new ApiContext();             
            
            try
            {
                var comentario = new Comentario()
                {
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Conteudo = rq.Conteudo,
                    IdUsuario = rq.IdUsuario,
                    IdPost = rq.IdPost                    
                };

                await context.Comentarios.AddAsync(comentario);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdateComentario(ComentarioRep rq)
        {
            using var context = new ApiContext();

            try
            {
                var comentario = new Comentario()
                {
                    DataAtualizacao = DateTime.Now,
                    Conteudo = rq.Conteudo,
                    IdUsuario = rq.IdUsuario,
                    IdPost = rq.IdPost,
                    Id = rq.Id
                };

                context.Comentarios.Update(comentario);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteComentario(int id)
        {
            using var context = new ApiContext();

            try
            {
                var comentario = await context.Comentarios.Where(x => x.Id == id).FirstOrDefaultAsync();

                context.Comentarios.RemoveRange(comentario);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
    }
}
