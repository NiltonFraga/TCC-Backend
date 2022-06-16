using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class AnimalFavoritoReq
    {
        public int Id { get; set; }
        public int IdAnimal { get; set; }
        public int IdUsuario { get; set; }
    }
}
