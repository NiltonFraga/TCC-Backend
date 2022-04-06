using Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IUsuarioRepo
    {
        Task<List<Usuario>> GetAllUsuario();
     //   Task<List<Usuario>> GetUsuarioByEmpresa(int id);
        Task<Usuario> GetUsuario(int id);
        Task PostUsuario(Usuario rq);
        Task UpdateUsuario(Usuario rq);
        Task DeleteUsuario(int id);
    }
}
