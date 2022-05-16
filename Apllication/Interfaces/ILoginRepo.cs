using Api.Domain;
using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces
{
    public interface ILoginRepo
    {
        Task<bool> UpdatePassword(string email, string password);
        Task<LoginRes> Login(string login, string password);
        Task<LoginRes> CriarUsuario(UsuarioReq usuario);
        //Task<Login> CriarEmpresa(Empresa usuario);
    }
}
