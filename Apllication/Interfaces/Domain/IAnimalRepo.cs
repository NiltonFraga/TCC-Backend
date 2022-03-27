using Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IAnimalRepo
    {
        Task<List<Animal>> GetAllAnimais();
        Task<Animal> GetAnimal(int id);
        Task PostAnimal(Animal rq);
        Task UpdateAnimal(Animal rq);
        Task DeleteAnimal(int id);
    }
}
