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
    public class Fornecedor : Pessoa
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        //public string CPF_CNPJ { get; set; }

        //public string Nome { get; set; }

        //public string Fisico_Juridico { get; set; }

        //private string tipo_pessoa;
        //public string Tipo_Pessoa
        //{
        //    get { return tipo_pessoa; }
        //    set { tipo_pessoa = "F"; }
        //}

        //public string Tipo_Pessoa { get; set; }

        public Fornecedor()
        {
            //this.tipo_pessoa = "F";
        }
    }
}
