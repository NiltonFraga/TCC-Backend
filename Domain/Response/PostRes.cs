using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Response
{
    public class PostRes
    {
        public int Id { get; set; }
        public string Topico { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public string NomeUsuario { get; set; }
        public int IdUsuario { get; set; }
        public int QuantComentarios { get; set; }
        public List<int> IdsUsuariosCurtidas { get; set; }
    }
}
