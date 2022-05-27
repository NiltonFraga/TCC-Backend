using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class ServicoReq
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string IdImagem { get; set; }
        public string Tipo { get; set; }
        public string Desconto { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public int DonoServico { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public DateTime DataCriacao { get; set; }
        public Arquivo Imagem { get; set; }
    }
}
