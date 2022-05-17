using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Repository.Domain
{
    public class AdocaoRepo : IAdocaoRepo
    {
        public async Task<List<Adocao>> GetAllAdocoes()
        {
            using var context = new ApiContext();

            List<Adocao> adocao = await context.Adocoes.ToListAsync();

            return adocao;
        }

        public async Task<Adocao> GetAdocao(int id)
        {
            using var context = new ApiContext();

            var adocao = await context.Adocoes.Where(x => x.Id == id).FirstOrDefaultAsync();

            return adocao;
        }

        public async Task PostAdocao(Adocao rq)
        {
            using var context = new ApiContext();

            await context.Adocoes.AddAsync(rq);

            await context.SaveChangesAsync();

        }

        public async Task UpdateAdocao(Adocao rq)
        {
            using var context = new ApiContext();

            context.Adocoes.Update(rq);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAdocao(int id)
        {
            using var context = new ApiContext();

            var adocao = await context.Adocoes.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Adocoes.Remove(adocao);

            await context.SaveChangesAsync();
        }
    }
}
