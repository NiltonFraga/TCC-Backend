using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Repository.Domain
{
    public class AnimalRepo : IAnimalRepo
    {
        public async Task<List<Animal>> GetAllAnimais()
        {
            using var context = new ApiContext();

            var animais = await context.Animals.ToListAsync();

            return animais;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            using var context = new ApiContext();

            var animal = await context.Animals.Where(x => x.Id == id).FirstOrDefaultAsync();

            return animal;
        }

        public async Task<List<Animal>> GetAnimalByEmpresa(int id)
        {
            using var context = new ApiContext();

            var animal = await context.Animals.Where(x => x.IdEmpresa == id).ToListAsync();

            return animal;
        }

        public async Task PostAnimal(Animal rq)
        {
            using var context = new ApiContext();

            await context.Animals.AddAsync(rq);

            await context.SaveChangesAsync();

        }

        public async Task UpdateAnimal(Animal rq)
        {
            using var context = new ApiContext();

            context.Animals.Update(rq);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAnimal(int id)
        {
            using var context = new ApiContext();

            var animal = await context.Animals.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Animals.Remove(animal);

            await context.SaveChangesAsync();
        }
    }
}
