using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Domain.Response;
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
        public async Task<List<AnimalAdocaoRes>> GetAllAnimais()
        {
            using var context = new ApiContext();

            var animais = await context.Animals
                .GroupJoin(
                  context.Usuarios,
                  i => i.Doador,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new AnimalAdocaoRes
                 {
                     Id = temp.i.Id,
                     Castrado = temp.i.Castrado,
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Endereco = temp.i.Endereco,
                     Foto = temp.i.Foto,
                     Idade = temp.i.Idade,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado,
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role
                 }).ToListAsync();

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

            var animal = await context.Animals.Where(x => x.Doador == id).ToListAsync();

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
