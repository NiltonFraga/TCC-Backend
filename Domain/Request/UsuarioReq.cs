using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class UsuarioReq
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Foto { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
    }
}
