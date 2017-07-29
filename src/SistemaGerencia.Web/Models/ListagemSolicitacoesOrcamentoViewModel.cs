using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class ListagemSolicitacoesOrcamentoViewModel
    {
        public int IdPessoa { get; set; }
        public string NomeCliente { get; set; }
        public List<SolicitacaoOrcamentoViewModel> Solicitacoes { get; set; }
    }
}