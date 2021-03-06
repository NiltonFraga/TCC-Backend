using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class ProdutoReq
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorReal { get; set; }
        public double ValorDesconto { get; set; }
        public string IdImagem { get; set; }
        public string Url { get; set; }
        public int IdServico { get; set; }
        public int IdDonoProduto { get; set; }
        public Arquivo Imagem { get; set; }
    }
}
