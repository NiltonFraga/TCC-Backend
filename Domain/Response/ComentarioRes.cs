using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Response
{
    public class ComentarioRes
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public string NomeUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int IdPost { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
