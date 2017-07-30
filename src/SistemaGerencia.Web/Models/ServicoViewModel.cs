using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class ServicoViewModel
    {
        public int Id { get; set; }
        public int IdOrcamento { get; set; }
        public string Descricao { get; set; }
    }
}