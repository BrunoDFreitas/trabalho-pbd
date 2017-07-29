﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class GravarSolicitacaoViewModel
    {
        public int IdPessoa { get; set; }
        public string Descricao { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public int IdEndereco { get; set; }
    }
}