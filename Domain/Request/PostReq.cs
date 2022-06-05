using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class PostReq
    {
        public int Id { get; set; }
        public string Topico { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int IdUsuario { get; set; }
    }
}
