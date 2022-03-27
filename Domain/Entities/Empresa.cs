using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain
{
    public class Empresa : Entity
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }
        public string Role { get; set; }
    }
}
