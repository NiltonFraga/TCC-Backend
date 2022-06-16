using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain
{
    public class Animal : Entity
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
        public int Doador { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string IdImagem { get; set; }
        public bool Ativo { get; set; }
    }
}
