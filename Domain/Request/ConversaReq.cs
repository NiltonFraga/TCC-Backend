using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class ConversaReq
    {
        public int UsuarioOrigem { get; set; }
        public int UsuarioDestino { get; set; }
        public string Menssagem { get; set; }
    }
}
