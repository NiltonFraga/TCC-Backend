using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IServicoRepo
    {
        Task<List<ServicoRes>> GetAllServisos();
        Task<ServicoRes> GetServicoById(int id);
        Task<List<ServicoRes>> GetServicoByTipo(string tipo);
        Task<ServicoRes> GetServicoByUsuario(int id);
        Task PostServico(ServicoReq rq);
        Task UpdateServico(ServicoReq rq);
        Task DeleteServico(int id);
    }
}
