using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IAnimalFavoritoRepo
    {
        Task UpdateAnimalFavorito(AnimalFavoritoReq rq);
    }
}
