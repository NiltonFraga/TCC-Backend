using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class AnimalReq
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Idade { get; set; }
        public string Sexo { get; set; }
        public double Peso { get; set; }
        public string Pelagem { get; set; }
        public bool Castrado { get; set; }
        public bool Vermifugado { get; set; }
        public string Doenca { get; set; }
        public string Vacina { get; set; }
        public string Descricao { get; set; }
        public string Guid { get; set; }
        public int Doador { get; set; }
        public string Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}
