﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Request
{
    public class UsuarioUpdateReq
    {
        public int Id { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
    }
}
