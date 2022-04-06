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
        public async Task<List<Adocao>> GetAllAdocao()
        {
            using var context = new ApiContext();

            List<Adocao> adocao = await context.Adocaos.ToListAsync();

            return adocao;
        }

        public async Task<Adocao> GetAdocao(int id)
        {
            using var context = new ApiContext();

            var adocao = await context.Adocaos.Where(x => x.Id == id).FirstOrDefaultAsync();

            return adocao;
        }

        /*public async Task<List<Usuario>> GetUsuarioByEmpresa(int id)
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios.Where(x => x.IdEmpresa == id).ToListAsync();

            return usuario;
        }
*/
        public async Task PostAdocao(Adocao rq)
        {
            using var context = new ApiContext();

            await context.Adocaos.AddAsync(rq);

            await context.SaveChangesAsync();

        }

        public async Task UpdateAdocao(Adocao rq)
        {
            using var context = new ApiContext();

            context.Adocaos.Update(rq);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAdocao(int id)
        {
            using var context = new ApiContext();

            var adocao = await context.Adocaos.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Adocaos.Remove(adocao);

            await context.SaveChangesAsync();
        }

        public Task<List<Adocao>> GetAdocaoByAdocao(int id)
        {
            throw new NotImplementedException();
        }
    }
}
