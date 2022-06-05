using Api.Domain.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface ICurtidaRepo
    {
        Task UpdateCurtida(CurtidaReq rq);
    }
}
