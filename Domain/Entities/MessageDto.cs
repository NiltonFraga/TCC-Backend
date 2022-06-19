using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class MessageDto
    {
        public string Destinatario { get; set; }
        public string User { get; set; }
        public string Menssagem { get; set; }
    }
}
