using SistemaGerencia.BaseModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class OrcamentoViewModel
    {
        public int Id { get; set; }
        public int IdSolicitacao { get; set; }
        public DateTime DataHoraEmissao { get; set; }
        public decimal ValorTotal { get; set; }
        public string TempoEstimado { get; set; }
        public string Garantia { get; set; }
        public string Status { get; set; }
        public string FormaPagamento { get; set; }
        public string Observacao { get; set; }
        public bool Novo { get; set; }

        public OrcamentoViewModel()
        {
            Novo = false;
        }


        public OrcamentoViewModel(Orcamento o)
        {
            this.Id = o.Id;
            this.IdSolicitacao = o.Solicitacao_Orcamento_Id;
            this.DataHoraEmissao = o.Data_Hora_Emissao;
            this.TempoEstimado = o.Tempo_Estimado;
            this.ValorTotal = o.Valor_Total;
            this.FormaPagamento = o.Forma_Pagamento;
            this.Garantia = o.Garantia;
            this.Status = o.Status;
            this.Observacao = o.Observacao;
        }
    }
}