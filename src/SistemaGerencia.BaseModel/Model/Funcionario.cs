using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.Model
{
    //[Table(name:"pessoa")]
    public class Funcionario : Colaborador
    {
        public DateTime? Data_Contratacao { get; set; }

        public decimal? Remuneracao { get; set; }

        public string Banco { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }
    }
}
