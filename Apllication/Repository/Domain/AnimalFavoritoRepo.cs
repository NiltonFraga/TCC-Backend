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
    public class AnimalFavoritoRepo : IAnimalFavoritoRepo
    {     
        public async Task UpdateAnimalFavorito(AnimalFavoritoReq rq)
        {
            using var context = new ApiContext();

            try
            {
                var like = await context.AnimalFavoritos.Where(x => x.IdAnimal == rq.IdAnimal && x.IdUsuario == rq.IdUsuario).FirstOrDefaultAsync();

                if (like == null)
                {
                    var animal = new AnimalFavorito()
                    {
                        IdAnimal = rq.IdAnimal,
                        IdUsuario = rq.IdUsuario
                    };

                    await context.AnimalFavoritos.AddAsync(animal);
                }
                else
                {      
                    context.AnimalFavoritos.Remove(like);
                }                

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
