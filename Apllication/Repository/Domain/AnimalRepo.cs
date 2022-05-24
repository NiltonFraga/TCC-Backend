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
                     Castrado = temp.i.Castrado,
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado,
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role,
                     Ativo = temp.i.Ativo
                 }).ToListAsync();

            foreach(var op in animais){
                var file = context.Arquivos.Where(x => x.Guid == op.Foto).FirstOrDefault();
                if(file != null)
                {
                    var base64 = System.Convert.ToBase64String(file.Dados);
                    var tipo = file.Tipo;
                    op.Foto = $@"data:{tipo};base64,{base64}";
                }
                else
                {
                    op.Foto = null;
                }                
            }

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
                     Castrado = temp.i.Castrado,
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado,
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role,
                     Ativo = temp.i.Ativo
                 }).FirstOrDefaultAsync();

            var file = context.Arquivos.Where(x => x.Guid == animal.Foto).FirstOrDefault();
            if (file != null)
            {
                var base64 = System.Convert.ToBase64String(file.Dados);
                var tipo = file.Tipo;
                animal.Foto = $@"data:{tipo};base64,{base64}";
            }
            else
            {
                animal.Foto = null;
            }

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
                     Castrado = temp.i.Castrado,
                     Descricao = temp.i.Descricao,
                     Doenca = temp.i.Doenca,
                     Rua = temp.i.Rua,
                     Bairro = temp.i.Bairro,
                     Cidade = temp.i.Cidade,
                     Idade = temp.i.Idade,
                     Foto = temp.i.Foto,
                     Nome = temp.i.Nome,
                     Pelagem = temp.i.Pelagem,
                     Peso = temp.i.Peso,
                     Tipo = temp.i.Tipo,
                     Vacina = temp.i.Vacina,
                     Vermifugado = temp.i.Vermifugado,
                     Sexo = temp.i.Sexo,
                     IdDoador = p.Id,
                     NomeDoador = p.Nome,
                     Role = p.Role,
                     Ativo = temp.i.Ativo
                 }).ToListAsync();

            foreach (var op in animais)
            {
                var file = context.Arquivos.Where(x => x.Guid == op.Foto).FirstOrDefault();
                if (file != null)
                {
                    var base64 = System.Convert.ToBase64String(file.Dados);
                    var tipo = file.Tipo;
                    op.Foto = $@"data:{tipo};base64,{base64}";
                }
                else
                {
                    op.Foto = null;
                }
            }

            return animais;
        }

        public async Task PostAnimal(AnimalReq rq)
        {
            using var context = new ApiContext(); 
            
            
            try
            {
                var animal = new Animal()
                {
                    Ativo = rq.Ativo,
                    Castrado = rq.Castrado,
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
                    Vermifugado = rq.Vermifugado,
                    Foto = rq.Guid
                };

                await context.Animals.AddAsync(animal);

                await context.SaveChangesAsync();
            }
            catch (Exception ec)
            {
                Console.WriteLine(ec);
            }
        }

        public async Task<bool> UploadImageAnimal(IFormFile file, string guid)
        {
            using var context = new ApiContext();
            
            try
            {

                MemoryStream ms = new MemoryStream();
                file.OpenReadStream().CopyTo(ms);

                var _file = new Arquivo()
                {
                    Nome = file.FileName,
                    Dados = ms.ToArray(),
                    Tipo = file.ContentType,
                    Guid = guid

                };

                await context.Arquivos.AddAsync(_file);
                await context.SaveChangesAsync();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return false;

            //var animal = await context.Animals.Where(x => x.Guid == guid).FirstOrDefaultAsync();

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
