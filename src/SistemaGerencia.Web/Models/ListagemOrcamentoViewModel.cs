using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class ListagemOrcamentoViewModel
    {
        public int IdPessoa { get; set; }
        public string NomeCliente { get; set; }

        public int IdSolicitacao { get; set; }
        public DateTime DataHoraSolicitacao { get; set; }
        public string DescricaoSolicitacao { get; set; }

        public EnderecoViewModel Endereco { get; set; }
    }
}