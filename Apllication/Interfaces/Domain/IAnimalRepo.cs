using Api.Domain;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IAnimalRepo
    {
        Task<List<AnimalAdocaoRes>> GetAllAnimais();
        Task<List<Animal>> GetAnimalByEmpresa(int id);
        Task<Animal> GetAnimal(int id);
        Task PostAnimal(Animal rq);
        Task UpdateAnimal(Animal rq);
        Task DeleteAnimal(int id);
    }
}
