using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Response
{
    public class ConversaRes
    {
        public int Id { get; set; }
        public int UsuarioOrigem { get; set; }
        public string NomeOrigem { get; set; }
        public int UsuarioDestino { get; set; }
        public string NomeDestino { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Menssagem { get; set; }
        public bool Leitura { get; set; }
    }
}
