using SistemaGerencia.BaseModel.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class SolicitacaoOrcamentoViewModel
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public int IdEndereco { get; set; }
        public string Status { get; set; }
        public DateTime DataHora { get; set; }
        public string Descricao { get; set; }

        public string DescricaoEndereco { get; set; }
        public string Endereco { get; set; }        
    }
}