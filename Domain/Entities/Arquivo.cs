using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class Arquivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Dados { get; set; }
        public string Tipo { get; set; }
        public string Guid { get; set; }
    }
}
