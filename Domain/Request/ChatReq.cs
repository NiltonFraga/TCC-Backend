using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class ChatReq
    {
        public int IdUsuario { get; set; }
        public int IdDestinatario { get; set; }
    }
}
