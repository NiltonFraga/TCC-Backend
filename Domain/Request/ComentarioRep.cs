using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class ComentarioRep
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public int IdUsuario { get; set; }
        public int IdPost { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
