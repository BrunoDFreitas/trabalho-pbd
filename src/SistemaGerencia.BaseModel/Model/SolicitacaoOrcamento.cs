using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.Model
{
    [Table(name:"solicitacao_orcamento")]
    public class SolicitacaoOrcamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Pessoa_Id { get; set; }

        public int Endereco_Id { get; set; }

        public DateTime Data_Hora { get; set; }

        public string Descricao { get; set; }

        public string Status { get; set; }
    }
}
