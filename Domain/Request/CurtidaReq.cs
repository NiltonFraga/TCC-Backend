using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class CurtidaReq
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
        public int IdUsuario { get; set; }
    }
}
