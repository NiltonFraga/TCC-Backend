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
    public class PostRepo : IPostRepo
    {
        public async Task<List<PostRes>> GetAllPost(PostFiltroReq filtroReq)
        {
            using var context = new ApiContext();
            try
            {
                var posts = await context.Posts
                    .GroupJoin(
                      context.Usuarios,
                      i => i.IdUsuario,
                      p => p.Id,
                      (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                      (temp, p) =>
                     new PostRes
                     {
                         Id = temp.i.Id,
                         Conteudo = temp.i.Conteudo,
                         DataAtualizacao = temp.i.DataAtualizacao ?? DateTime.Now,
                         NomeUsuario = p.Nome,
                         Topico = temp.i.Topico,
                         IdUsuario = p.Id,
                         QuantComentarios = context.Comentarios.Where(x => x.IdPost == temp.i.Id).Count(),
                         IdsUsuariosCurtidas = context.Curtidas.Where(x => x.IdPost == temp.i.Id).Select(x => x.IdUsuario).ToList()
                     }).ToListAsync();

                if (filtroReq.Topico != "Todos")
                {
                    posts = posts.Where(x => x.Topico == filtroReq.Topico).ToList();
                }
                
                if(filtroReq.Usuario != 0)
                {
                    posts = posts.Where(x => x.IdUsuario == filtroReq.Usuario).ToList();
                }

                return posts.OrderByDescending(x => x.DataAtualizacao).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<PostAndComentarioRes> GetPostAndComentarioById(int id)
        {
            using var context = new ApiContext();

            try
            {
                var comentarios = context.Comentarios
                .Where(x => x.IdPost == id)
                .GroupJoin(
                  context.Usuarios,
                  i => i.IdUsuario,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new ComentarioRes
                 {
                     Id = temp.i.Id,
                     Conteudo = temp.i.Conteudo,
                     NomeUsuario = p.Nome,
                     IdPost = temp.i.IdPost,
                     IdUsuario = p.Id,
                     DataAtualizacao = temp.i.DataAtualizacao ?? DateTime.Now
                 }).ToList();

                var post = await context.Posts.Where(x => x.Id == id)
                    .GroupJoin(
                      context.Usuarios,
                      i => i.IdUsuario,
                      p => p.Id,
                      (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                      (temp, p) =>
                     new PostAndComentarioRes
                     {
                         Id = temp.i.Id,
                         Conteudo = temp.i.Conteudo,
                         DataAtualizacao = temp.i.DataAtualizacao ?? DateTime.Now,
                         NomeUsuario = p.Nome,
                         IdUsuario = p.Id,
                         Topico = temp.i.Topico,
                         Comentarios = comentarios,
                         QuantComentarios = comentarios.Count,
                         IdsUsuariosCurtidas = context.Curtidas.Where(x => x.IdPost == temp.i.Id).Select(x => x.IdUsuario).ToList()
                     }).FirstOrDefaultAsync();

                return post;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }

        public async Task<PostRes> GetPostById(int id)
        {
            using var context = new ApiContext();

            try
            {
                var post = await context.Posts.Where(x => x.Id == id)
                    .GroupJoin(
                      context.Usuarios,
                      i => i.IdUsuario,
                      p => p.Id,
                      (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                      (temp, p) =>
                     new PostRes
                     {
                         Id = temp.i.Id,
                         Conteudo = temp.i.Conteudo,
                         Topico = temp.i.Topico,
                         IdUsuario = p.Id
                     }).FirstOrDefaultAsync();

                return post;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task PostPost(PostReq rq)
        {
            using var context = new ApiContext();             
            
            try
            {
                var post = new Post()
                {
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Conteudo = rq.Conteudo,
                    IdUsuario = rq.IdUsuario,
                    Topico = rq.Topico
                };

                await context.Posts.AddAsync(post);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task UpdatePost(PostReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var post = new Post()
                {
                    DataAtualizacao = DateTime.Now,
                    Conteudo = rq.Conteudo,
                    IdUsuario = rq.IdUsuario,
                    Topico = rq.Topico,
                    Id = rq.Id
                };

                context.Posts.Update(post);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeletePost(int id)
        {
            using var context = new ApiContext();

            try
            {
                var post = await context.Posts.Where(x => x.Id == id).FirstOrDefaultAsync();
                var comentarios = await context.Comentarios.Where(x => x.IdPost == id).ToListAsync();
                var curtidas = await context.Curtidas.Where(x => x.IdPost == id).ToListAsync();

                context.Posts.Remove(post);
                context.Comentarios.RemoveRange(comentarios);
                context.Curtidas.RemoveRange(curtidas);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }            
        }
    }
}
