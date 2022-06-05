using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IComentarioRepo
    {
        Task<ComentarioRes> GetComentarioById(int id);
        Task PostComentario(ComentarioRep rq);
        Task UpdateComentario(ComentarioRep rq);
        Task DeleteComentario(int id);
    }
}
