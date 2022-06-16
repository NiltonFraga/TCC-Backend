using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Response
{
    public class UsuarioRes
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Role { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public int QuantSevicosCadastrados { get; set; }
        public int QuantProdutosCadastrados { get; set; }
        public int QuantAnimaisDoados { get; set; }
    }
}
