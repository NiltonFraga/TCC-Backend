using Api.Domain;
using Api.Domain.Request;
using Api.Domain.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IAnimalRepo
    {
        Task<List<AnimalAdocaoRes>> GetAllAnimais();
        Task<AnimalAdocaoRes> GetAnimal(int id);
        Task<List<AnimalAdocaoRes>> GetAnimalByUsuario(int id);
        Task PostAnimal(AnimalReq rq);
        Task UpdateAnimal(AnimalReq rq);
        Task DeleteAnimal(int id);
        Task<List<AnimalAdocaoRes>> GetAnimaisFavorito(int id);
    }
}
