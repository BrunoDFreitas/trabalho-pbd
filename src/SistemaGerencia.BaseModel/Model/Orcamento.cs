using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.Model
{
    [Table(name:"orcamento")]
    public class Orcamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Solicitacao_Orcamento_Id { get; set; }
        public DateTime Data_Hora_Emissao { get; set; }
        public decimal Valor_Total { get; set; }
        public string Tempo_Estimado { get; set; }
        public string Status { get; set; }
        public string Garantia { get; set; }
        public string Observacao { get; set; }
        public string Forma_Pagamento { get; set; }
    }
}
