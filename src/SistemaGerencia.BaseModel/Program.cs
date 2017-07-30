using SistemaGerencia.BaseModel.Model;
using SistemaGerencia.BaseModel.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel
{
    public class Program
    {
        static int Main(string[] arg)
        {
            UnitOfWork unit = new UnitOfWork();
            Pessoa pessoa = unit.Pessoa.FindById(1);
            unit.Dispose();

            unit = new UnitOfWork();
            List<Endereco> enderecos = unit.Endereco.ConsultaPorPessoaId(pessoa.Id).ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Cliente> clientes = unit.Cliente.ConsultaTodosClientes().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Cliente> clientesAll = unit.Cliente.All().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Fornecedor> fornecedores = unit.Fornecedor.ConsultaTodosFornecedores().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<PrestadorServico> prestadoresSerivico = unit.PrestadorServico.ConsultaTodosPrestadoresServico().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<ServidorTerceirizado> servidoresTerceirizados = unit.ServidorTerceirizado.ConsultaTodosServidoresTerceirizado().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Colaborador> colaboradores = unit.Colaborador.ConsultaTodosColaboradores().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Socio> socios = unit.Socio.ConsultaTodosSocios().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Funcionario> funcionarios = unit.Funcionario.ConsultaTodosFuncionarios().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<SolicitacaoOrcamento> solicitacoesOrcamento = unit.SolicitacaoOrcamento.All().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
            List<Orcamento> orcamentos = unit.Orcamento.All().ToList();
            unit.Dispose();

            unit = new UnitOfWork();
           List<Servico> servicos = unit.Servico.All().ToList();
            unit.Dispose();


            return 0;
        }
    }
}
