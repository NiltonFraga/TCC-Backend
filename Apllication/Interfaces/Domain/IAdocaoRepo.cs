using Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IAdocaoRepo
    {
        Task<List<Adocao>> GetAllAdocoes();
        Task<Adocao> GetAdocao(int id);
        Task PostAdocao(Adocao rq);
        Task UpdateAdocao(Adocao rq);
        Task DeleteAdocao(int id);
    }
}
