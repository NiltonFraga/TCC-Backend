using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class ChatDto
    {
        public int Id { get; set; }
        public int User { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Guid { get; set; }
    }
}
