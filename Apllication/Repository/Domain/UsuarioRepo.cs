using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
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
    public class UsuarioRepo : IUsuarioRepo
    {
        public async Task<List<Usuario>> GetAllUsuarios()
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

        public async Task<Usuario> GetUsuarioByLogin(string login, string password)
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios
                .Where(x => x.Email == login && x.Senha == password).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task PostUsuario(UsuarioReq rq)
        {
            using var context = new ApiContext();

            var user = new Usuario()
            {
                Email = rq.Email,
                Documento = rq.Documento,
                Foto = rq.Foto,
                Telefone1 = rq.Telefone1,
                Telefone2 = rq.Telefone2,
                Nome = rq.Nome,
                Role = rq.Role,
                Senha = rq.Senha,
                DataCriacao = DateTime.Now,
                DataAtualizacao = DateTime.Now
            };

            await context.Usuarios.AddAsync(user);

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

        public async Task<LoginRes> UpdateToken(Usuario user, string token)
        {
            using ApiContext context = new ApiContext();

            user.Token = token;

            context.Usuarios.Update(user);

            await context.SaveChangesAsync();

            var res = new LoginRes()
            { 
                Id = user.Id,
                Nome = user.Nome,
                Email = user.Email,
                Telefone1 = user.Telefone1,
                Telefone2 = user.Telefone2,
                Foto = user.Foto,
                Role = user.Role,
                Token = user.Token,
                Documento = user.Documento
            };

            return res;
        }

        public async Task<bool> UpdatePassword(string email, string password)
        {
            using ApiContext context = new ApiContext();

            var usuario = await context.Usuarios.Where(x => x.Email == email).FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            usuario.Senha = password;

            context.Usuarios.Update(usuario);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
