using SistemaGerencia.BaseModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Descricao { get; set; }
        public bool Editar { get; set; }

        public EnderecoViewModel()
        {
            Editar = true;
        }

        public EnderecoViewModel(Endereco e)
        {
            this.Id = e.Id;
            this.IdPessoa = e.Pessoa_Id;
            this.Descricao = e.Descricao;
            this.UF = e.UF;
            this.Cidade = e.Cidade;
            this.Bairro = e.Bairro;
            this.Rua = e.Rua;
            this.Numero = e.Numero;
            this.Complemento = e.Complemento;
            this.Editar = true;
        }
    }
}