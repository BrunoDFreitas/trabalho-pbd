using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaGerencia.Web.Models
{
    public static class Constantes
    {
        public static Dictionary<string, string> OpcoesSimNao = new Dictionary<string, string>()
        {
            { "S", "Sim" },
            { "N", "Não" }
        };

        public static Dictionary<string, string> StatusOrcamento = new Dictionary<string, string>()
        {
            { "P", "Pendente de Aprovação" },
            { "A", "Aprovado" },
            { "R", "Reprovado" }
        };

        //public static List<string> Opcoes
    }
}