using Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Interfaces.Domain
{
    public interface IEmpresaRepo
    {
        List<Empresa> GetAllEmpresas();
    }
}
