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
    public class ChatRepo : IChatRepo
    {
        public async Task<List<ChatRes>> GetChatById(int id)
        {
            using var context = new ApiContext();

            try
            {
                var rooms = await context.Chats.Where(x => x.User == id).Select(x => x.Guid).ToListAsync();

                var chatsRenetente = await context.Chats.Where(x => x.User != id && rooms.Contains(x.Guid))
                    .GroupJoin(
                      context.Usuarios,
                      i => i.User,
                      p => p.Id,
                      (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                      (temp, p) =>
                     new ChatRes
                     {
                         Id = temp.i.Id,
                         Destinatario = p.Nome,
                         IdDestinatario = p.Id,
                         DataCriacao = temp.i.DataCriacao,
                         Guid = temp.i.Guid
                     }).OrderByDescending(x => x.DataCriacao).ToListAsync();

                return chatsRenetente;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task PostChat(ChatReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var conversas = new List<ChatDto>();

                conversas.Add(new ChatDto()
                {
                    DataCriacao = DateTime.Now,
                    User = rq.IdDestinatario,
                    Guid = guid
                });

                conversas.Add(new ChatDto()
                {
                    DataCriacao = DateTime.Now,
                    User = rq.IdUsuario,
                    Guid = guid
                });

                await context.Chats.AddRangeAsync(conversas);

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
