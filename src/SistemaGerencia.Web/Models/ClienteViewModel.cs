using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string CPFCNPJ { get; set; }
        public string Nome { get; set; }
        public string Ramo { get; set; }
    }
}