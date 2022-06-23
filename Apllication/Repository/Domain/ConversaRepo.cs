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
    public class ConversaRepo : IConversaRepo
    {
        public async Task<List<ConversaRes>> GetConversas(int userRequest, int userDestine)
        {
            using var context = new ApiContext();

            try
            {
                var chatsRenetente = await context.Conversas
                    .Where(x => (x.UsuarioOrigem == userRequest && x.UsuarioDestino == userDestine) || (x.UsuarioOrigem == userDestine && x.UsuarioDestino == userRequest))
                    .Select(x => new ConversaRes
                    {
                        Id = x.Id,
                        DataCriacao = x.DataCriacao,
                        Menssagem = x.Menssagem,
                        UsuarioOrigem = x.UsuarioOrigem,
                        UsuarioDestino = x.UsuarioDestino,
                        NomeDestino = context.Usuarios.Where(z => z.Id == x.UsuarioDestino).Select(z => z.Nome).FirstOrDefault(),
                        NomeOrigem = context.Usuarios.Where(z => z.Id == x.UsuarioOrigem).Select(z => z.Nome).FirstOrDefault(),
                        Leitura = x.Leitura
                    }).ToListAsync();

                var mensagensLidas = chatsRenetente.Where(x => x.UsuarioDestino == userRequest && x.Leitura == false).Select(x => new Conversa 
                { 
                    Id = x.Id,
                    DataCriacao = x.DataCriacao,
                    Menssagem =  x.Menssagem,
                    UsuarioDestino = x.UsuarioDestino,
                    UsuarioOrigem = x.UsuarioOrigem,
                    Leitura = true
                }).ToList();

                if (mensagensLidas.Count > 0)
                {
                    context.Conversas.UpdateRange(mensagensLidas);
                    await context.SaveChangesAsync();
                }

                return chatsRenetente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<ConversaRes>> GetByDestino(int userRequest, int userDestine)
        {
            using var context = new ApiContext();

            try
            {
                var chatsRenetente = await context.Conversas
                    .Where(x => x.UsuarioOrigem == userDestine && x.UsuarioDestino == userRequest && x.Leitura == false)
                    .Select(x => new ConversaRes
                    {
                        Id = x.Id,
                        DataCriacao = x.DataCriacao,
                        Menssagem = x.Menssagem,
                        UsuarioOrigem = x.UsuarioOrigem,
                        UsuarioDestino = x.UsuarioDestino,
                        NomeDestino = context.Usuarios.Where(z => z.Id == x.UsuarioDestino).Select(z => z.Nome).FirstOrDefault(),
                        NomeOrigem = context.Usuarios.Where(z => z.Id == x.UsuarioOrigem).Select(z => z.Nome).FirstOrDefault(),
                        Leitura = x.Leitura
                    }).ToListAsync();

                var mensagensLidas = chatsRenetente.Select(x => new Conversa
                {
                    Id = x.Id,
                    DataCriacao = x.DataCriacao,
                    Menssagem = x.Menssagem,
                    UsuarioDestino = x.UsuarioDestino,
                    UsuarioOrigem = x.UsuarioOrigem,
                    Leitura = true
                }).ToList();

                if(mensagensLidas.Count > 0)
                {
                    context.Conversas.UpdateRange(mensagensLidas);
                    await context.SaveChangesAsync();
                }


                return chatsRenetente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task PostConversa(ConversaReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var conversa = new Conversa()
                {
                    Menssagem = rq.Menssagem,
                    UsuarioDestino = rq.UsuarioDestino,
                    UsuarioOrigem = rq.UsuarioOrigem,
                    DataCriacao = DateTime.Now,
                    Leitura = false
                };

                await context.Conversas.AddAsync(conversa);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteChat(int id)
        {
            using var context = new ApiContext();

            try
            {
                var chat = await context.Chats.Where(x => x.Id == id).FirstOrDefaultAsync();

                context.Chats.RemoveRange(chat);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
