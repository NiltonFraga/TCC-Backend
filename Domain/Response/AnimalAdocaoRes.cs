using Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
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
        public string Castrado { get; set; }
        public string Vermifugado { get; set; }
        public string Doenca { get; set; }
        public string Vacina { get; set; }
        public string Descricao { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int IdDoador { get; set; }
        public string NomeDoador { get; set; }
        public string Ativo { get; set; }
        public string Img { get; set; }
        public Arquivo Imagem { get; set; }
        public string Role { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public List<int> IdsUsuariosQueFavoritaram { get; set; }
        public DateTime? DataCriacao { get; set; }
    }
}
