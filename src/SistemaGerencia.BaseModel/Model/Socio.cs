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
    public class Socio : Colaborador
    {
        public decimal? Pro_Labore { get; set; }
    }
}
