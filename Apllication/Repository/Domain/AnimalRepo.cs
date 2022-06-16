using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Domain.Entities;
using Api.Domain.Request;
using Api.Domain.Response;
using Api.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
                     Castrado = temp.i.Castrado == true ? "true" : "false",
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado == true ? "true" : "false",
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Role = p.Role,
                     Ativo = temp.i.Ativo == true ? "true" : "false",
                     Img = ""
                 }).ToListAsync();

            return animais;
        }

        public async Task<AnimalAdocaoRes> GetAnimal(int id)
        {
            using var context = new ApiContext();

            var animal = await context.Animals.Where(x => x.Id == id)
                .GroupJoin(
                  context.Usuarios,
                  i => i.Doador,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new AnimalAdocaoRes
                 {
                     Id = temp.i.Id,
                     Castrado = temp.i.Castrado == true ? "true" : "false",
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado == true ? "true" : "false",
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role,
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Ativo = temp.i.Ativo == true ? "true" : "false",
                     Img = "",
                     Telefone1 = p.Telefone1,
                     Telefone2 = p.Telefone2,
                     IdsUsuariosQueFavoritaram = context.AnimalFavoritos.Where(x => x.IdAnimal == temp.i.Id).Select(x => x.IdUsuario).ToList()
                 }).FirstOrDefaultAsync();

            return animal;
        }

        public async Task<List<AnimalAdocaoRes>> GetAnimalByUsuario(int id)
        {
            using var context = new ApiContext();

            var animais = await context.Animals.Where(x => x.Doador == id)
                .GroupJoin(
                  context.Usuarios,
                  i => i.Doador,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new AnimalAdocaoRes
                 {
                     Id = temp.i.Id,
                     Castrado = temp.i.Castrado == true ? "true" : "false",
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado == true ? "true" : "false",
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role,
                     Ativo = temp.i.Ativo == true ? "true" : "false",
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Img = ""
                 }).ToListAsync();

            return animais;
        }

        public async Task<List<AnimalAdocaoRes>> GetAnimaisFavorito(int id)
        {
            using var context = new ApiContext();

            var favoritos = await context.AnimalFavoritos.Where(x => x.IdUsuario == id).Select(x => x.IdAnimal).ToListAsync();

            var animais = await context.Animals.Where(x => favoritos.Contains(x.Id))
                .GroupJoin(
                  context.Usuarios,
                  i => i.Doador,
                  p => p.Id,
                  (i, p) => new { i, p }).SelectMany(temp => temp.p.DefaultIfEmpty(),
                  (temp, p) =>
                 new AnimalAdocaoRes
                 {
                     Id = temp.i.Id,
                     Castrado = temp.i.Castrado == true ? "true" : "false",
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado == true ? "true" : "false",
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role,
                     Ativo = temp.i.Ativo == true ? "true" : "false",
                     Imagem = context.Arquivos.Where(x => x.Guid == temp.i.IdImagem).FirstOrDefault(),
                     Img = ""
                 }).ToListAsync();

            return animais;
        }

        public async Task PostAnimal(AnimalReq rq)
        {
            using var context = new ApiContext(); 
            
            
            try
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var animal = new Animal()
                {
                    Ativo = rq.Ativo == "true",
                    Castrado = rq.Castrado == "true",
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Descricao = rq.Descricao,
                    Doador = rq.Doador,
                    Doenca = rq.Doenca,
                    Rua = rq.Rua,
                    Bairro = rq.Bairro,
                    Cidade = rq.Cidade,
                    Idade = rq.Idade,
                    Nome = rq.Nome,
                    Pelagem = rq.Pelagem,
                    Peso = rq.Peso,
                    Sexo = rq.Sexo,
                    Tipo = rq.Tipo,
                    Vacina = rq.Vacina,
                    Vermifugado = rq.Vermifugado == "true",
                    IdImagem = guid
                };

                var imagem = new Arquivo()
                {
                    Guid = guid,
                    Nome = rq.Imagem.Nome,
                    Tipo = rq.Imagem.Tipo,
                    Dados = rq.Imagem.Dados,
                };

                await context.Animals.AddAsync(animal);
                await context.Arquivos.AddAsync(imagem);

                await context.SaveChangesAsync();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec);
            }
        }

        public async Task UpdateAnimal(AnimalReq rq)
        {
            using var context = new ApiContext();
            
            try
            {
                var guid = Guid.NewGuid().ToString().Replace("-", "");

                var animal = new Animal()
                {
                    Id = rq.Id,
                    Ativo = rq.Ativo == "true",
                    Castrado = rq.Castrado == "true",
                    DataAtualizacao = DateTime.Now,
                    DataCriacao = DateTime.Now,
                    Descricao = rq.Descricao,
                    Doador = rq.Doador,
                    Doenca = rq.Doenca,
                    Rua = rq.Rua,
                    Bairro = rq.Bairro,
                    Cidade = rq.Cidade,
                    Idade = rq.Idade,
                    Nome = rq.Nome,
                    Pelagem = rq.Pelagem,
                    Peso = rq.Peso,
                    Sexo = rq.Sexo,
                    Tipo = rq.Tipo,
                    Vacina = rq.Vacina,
                    Vermifugado = rq.Vermifugado == "true",
                    IdImagem = guid
                };

                var imagem = new Arquivo()
                {
                    Id = rq.Imagem.Id,
                    Guid = guid,
                    Nome = rq.Imagem.Nome,
                    Tipo = rq.Imagem.Tipo,
                    Dados = rq.Imagem.Dados,
                };

                context.Animals.Update(animal);
                context.Arquivos.Update(imagem);
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAnimal(int id)
        {
            using var context = new ApiContext();

            var animal = await context.Animals.Where(x => x.Id == id).FirstOrDefaultAsync();
            var imagem = await context.Arquivos.Where(x => x.Id == id).FirstOrDefaultAsync();

            context.Animals.Remove(animal);
            context.Arquivos.Remove(imagem);

            await context.SaveChangesAsync();
        }
    }
}
