using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class CadastroSolicitacaoOrcamentoViewModel
    {
        public int IdPessoa { get; set; }
        public string NomePessoa { get; set; }

        public List<ResumoEnderecoViewModel> Enderecos { get; set; }
    }
}