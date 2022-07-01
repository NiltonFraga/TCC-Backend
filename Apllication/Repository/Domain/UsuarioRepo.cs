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

        public async Task<UsuarioRes> GetUsuario(int id)
        {
            using var context = new ApiContext();

            var user = await context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();

            var usuario = new UsuarioRes()
            {
                Nome = user.Nome,
                Documento = user.Documento,
                Email = user.Email,
                Role = user.Role,
                Telefone1 = user.Telefone1,
                Telefone2 = user.Telefone2,
                QuantAnimaisDoados = await context.Animals.Where(x => x.Doador == user.Id && x.Ativo == false).CountAsync(),
                QuantSevicosCadastrados = await context.Servicos.Where(x => x.DonoServico == user.Id).CountAsync(),
                QuantProdutosCadastrados = await context.Produtos.Where(x => x.IdDonoProduto == user.Id).CountAsync(),
            };

            return usuario;
        }

        public async Task UpdateCredenciais(UsuarioUpdateReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var usuario = await context.Usuarios.Where(x => x.Id == rq.Id).FirstOrDefaultAsync();

                if (!string.IsNullOrEmpty(rq.Senha))
                    usuario.Senha = rq.Senha;

                if (!string.IsNullOrEmpty(rq.Email))
                    usuario.Email = rq.Email;

                if (!string.IsNullOrEmpty(rq.Nome))
                    usuario.Nome = rq.Nome;

                if (!string.IsNullOrEmpty(rq.Telefone1))
                    usuario.Telefone1 = rq.Telefone1;

                if (!string.IsNullOrEmpty(rq.Telefone2))
                    usuario.Telefone2 = rq.Telefone2;

                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteUsuario(int id)
        {
            using var context = new ApiContext();

            try
            {
                var usuario = await context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
                var animal = await context.Animals.Where(x => x.Doador == id).ToArrayAsync();
                var servico = await context.Servicos.Where(x => x.DonoServico == id).ToArrayAsync();
                var produto = await context.Produtos.Where(x => x.IdDonoProduto == id).ToArrayAsync();
                var post = await context.Posts.Where(x => x.IdUsuario == id).ToArrayAsync();
                var comentario = await context.Comentarios.Where(x => x.IdUsuario == id).ToArrayAsync();
                var curtida = await context.Curtidas.Where(x => x.IdUsuario == id).ToArrayAsync();
                var favoritos = await context.AnimalFavoritos.Where(x => x.IdUsuario == id).ToArrayAsync();

                context.Usuarios.Remove(usuario);
                context.Animals.RemoveRange(animal);
                context.Servicos.RemoveRange(servico);
                context.Produtos.RemoveRange(produto);
                context.Posts.RemoveRange(post);
                context.Comentarios.RemoveRange(comentario);
                context.Curtidas.RemoveRange(curtida);
                context.AnimalFavoritos.RemoveRange(favoritos);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<Usuario> GetUsuarioByLogin(string login, string password)
        {
            using var context = new ApiContext();

            var usuario = await context.Usuarios
                .Where(x => x.Email == login && x.Senha == password).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario> GetUsuarioByEmailAndDoc(string email, string doc)
        {
            using var context = new ApiContext();

            return await context.Usuarios
                .Where(x => x.Email == email || x.Documento == doc).FirstOrDefaultAsync();
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
