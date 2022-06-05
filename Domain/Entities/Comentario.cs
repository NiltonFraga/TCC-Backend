using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Comentario : Entity
    {
        public string Conteudo { get; set; }
        public int IdPost { get; set; }
        public int IdUsuario { get; set; }
    }
}
