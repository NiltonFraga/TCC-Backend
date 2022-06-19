using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Conversa
    {
        public int Id { get; set; }
        public int UsuarioOrigem { get; set; }
        public int UsuarioDestino { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Menssagem { get; set; }
        public bool Leitura { get; set; }
    }
}
