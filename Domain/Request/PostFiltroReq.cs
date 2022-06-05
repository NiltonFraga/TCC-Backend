using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class PostFiltroReq
    {
        public string Topico { get; set; }
        public int Usuario { get; set; }
    }
}
