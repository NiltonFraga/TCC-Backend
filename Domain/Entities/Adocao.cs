using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain
{
    public class Adocao : Entity
    {
        public int IdAnimal { get; set; }
        public bool Interece { get; set; }
        public bool Adotado { get; set; }
        public DateTime DataAdocao { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpresa { get; set; }
    }
}
