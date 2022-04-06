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
    public class UsuarioRepo : IUsuarioRepo
    {
        public async Task<List<Usuario>> GetAllUsuario()
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios.ToListAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();

            return usuario;
        }

        /*public async Task<List<Usuario>> GetUsuarioByEmpresa(int id)
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios.Where(x => x.IdEmpresa == id).ToListAsync();

            return usuario;
        }
*/
        public async Task PostUsuario(Usuario rq)
        {
            using var context = new ApiContext();

            await context.Usuarios.AddAsync(rq);

            await context.SaveChangesAsync();

        }

        public async Task UpdateUsuario(Usuario rq)
        {
            using var context = new ApiContext();

            context.Usuarios.Update(rq);

            await context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(int id)
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Usuarios.Remove(usuario);

            await context.SaveChangesAsync();
        }
    }
}
