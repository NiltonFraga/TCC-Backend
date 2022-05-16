using Api.Domain;
using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IUsuarioRepo
    {
        Task<List<Usuario>> GetAllUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> GetUsuarioByLogin(string login, string password);
        Task PostUsuario(UsuarioReq rq);
        Task UpdateUsuario(Usuario rq);
        Task DeleteUsuario(int id);
        Task<LoginRes> UpdateToken(Usuario user, string token);
        Task<bool> UpdatePassword(string email, string password);
    }
}
