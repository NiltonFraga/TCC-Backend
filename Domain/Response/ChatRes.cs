using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Response
{
    public class ChatRes
    {
        public int Id { get; set; }
        public string Destinatario { get; set; }
        public int IdDestinatario { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Guid { get; set; }
    }
}
