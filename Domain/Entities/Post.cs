using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Post : Entity
    {
        public string Topico { get; set; }
        public int IdUsuario { get; set; }
        public string Conteudo { get; set; }
    }
}
