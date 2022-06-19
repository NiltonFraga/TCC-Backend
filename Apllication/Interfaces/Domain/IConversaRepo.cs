using Api.Domain.Request;
using Api.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IConversaRepo
    {
        Task<List<ConversaRes>> GetConversas(int userRequest, int userDestine);
        Task<List<ConversaRes>> GetByDestino(int userRequest, int userDestine);
        Task PostConversa(ConversaReq rq);
    }
}
