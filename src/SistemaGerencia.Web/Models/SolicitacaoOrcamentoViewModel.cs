﻿using SistemaGerencia.BaseModel.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class SolicitacaoOrcamentoViewModel
    {
        public int IdSolicitacao { get; set; }
        public int IdPessoa { get; set; }
        public string NomeCliente { get; set; }
        public int IdEndereco { get; set; }
        public string Status { get; set; }
        public DateTime DataHoraSolicitacao { get; set; }
        public string DescricaoSolicitacao { get; set; }


        public EnderecoViewModel Endereco { get; set; }

        public List<OrcamentoViewModel> Orcamentos { get; set; }
    }
}