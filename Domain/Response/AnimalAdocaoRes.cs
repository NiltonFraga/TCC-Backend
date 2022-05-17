using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Response
{
    public class AnimalAdocaoRes
    {
        public int Id { get; set; }
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
        public string Endereco { get; set; }
        public string Foto { get; set; }
        public int IdDoador { get; set; }
        public string NomeDoador { get; set; }
        public string Role { get; set; }
    }
}
