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
    public class CurtidaRepo : ICurtidaRepo
    {     
        public async Task UpdateCurtida(CurtidaReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var like = await context.Curtidas.Where(x => x.IdPost == rq.IdPost && x.IdUsuario == rq.IdUsuario).FirstOrDefaultAsync();

                if (like == null)
                {
                    var curtida = new Curtida()
                    {
                        IdPost = rq.IdPost,
                        IdUsuario = rq.IdUsuario
                    };

                    await context.Curtidas.AddAsync(curtida);
                }
                else
                {      
                    context.Curtidas.Remove(like);
                }                

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
