using SistemaGerencia.BaseModel.Model;
using SistemaGerencia.BaseModel.Unit;
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
        public List<EnderecoViewModel> Enderecos { get; set; }

        public bool CarregaDadosCliente(int id, bool carregarEnderecos = true)
        {
            UnitOfWork unit = null;
            try
            {
                unit = new UnitOfWork();
                Cliente bdCliente = unit.Cliente.FindById(id);
                if (bdCliente != null)
                {
                    Id = bdCliente.Id;
                    CPFCNPJ = bdCliente.CPF_CNPJ;
                    Nome = bdCliente.Nome;
                    Ramo = bdCliente.Ramo;

                    if (carregarEnderecos)
                    {
                        Enderecos = unit.Endereco.ConsultaPorPessoaId(bdCliente.Id)
                          .Select(e => new EnderecoViewModel()
                          {
                              Id = e.Id,
                              IdPessoa = e.Pessoa_Id,
                              UF = e.UF,
                              Cidade = e.Cidade,
                              Bairro = e.Bairro,
                              Rua = e.Rua,
                              Numero = e.Numero,
                              Complemento = e.Complemento,
                              Descricao = e.Descricao
                          }).ToList();
                    }
                }

                return false;
            }
            finally
            {
                if (unit != null)
                    unit.Dispose();

                unit = null;
            }
        }
    }
}