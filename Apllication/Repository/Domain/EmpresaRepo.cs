using Api.Apllication.Interfaces;
using Api.Apllication.Interfaces.Domain;
using Api.Domain;
using Api.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Apllication.Repository.Domain
{
    public class EmpresaRepo : IEmpresaRepo
    {
        
         public List<Empresa> GetAllEmpresas()
        {
            using var context = new ApiContext();

           
        var empresas = context.Empresas.ToList();

            return empresas;
        }
    }
}
