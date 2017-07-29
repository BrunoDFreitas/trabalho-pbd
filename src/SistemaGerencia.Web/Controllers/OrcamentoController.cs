using SistemaGerencia.BaseModel.Model;
using SistemaGerencia.BaseModel.Unit;
using SistemaGerencia.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGerencia.Web.Controllers
{
    public class OrcamentoController : Controller
    {
        // GET: Orcamento
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SolicitacoesCliente(int id)
        {
            UnitOfWork unit = null;
            try
            {
                unit = new UnitOfWork();
                Cliente bdCliente = unit.Cliente.FindById(id);
                if (bdCliente == null)
                {
                    ViewBag.Retorno = "Cliente não encontrado";
                    return RedirectToAction("Index", "Home");
                }

                ListagemSolicitacoesOrcamentoViewModel solicitacoes = new ListagemSolicitacoesOrcamentoViewModel()
                {
                    IdPessoa = bdCliente.Id,
                    NomeCliente = bdCliente.Nome
                };

                IQueryable<SolicitacaoOrcamento> bdSolicitacoes = unit.SolicitacaoOrcamento.ConsultaPorIdPessoa(bdCliente.Id);
                IQueryable<Endereco> bdEndereco = unit.Endereco.ConsultaPorPessoaId(bdCliente.Id);


                solicitacoes.Solicitacoes = bdSolicitacoes.Join(bdEndereco
                    , s => s.Endereco_Id
                    , e => e.Id
                    , (s, e) => new SolicitacaoOrcamentoViewModel()
                    {
                        IdSolicitacao = s.Id,
                        IdPessoa = s.Pessoa_Id,
                        IdEndereco = s.Endereco_Id,
                        DataHoraSolicitacao = s.Data_Hora,
                        DescricaoSolicitacao = s.Descricao,
                        Status = s.Status,
                        Endereco = new EnderecoViewModel()
                        {
                            Id = e.Id,
                            Descricao = e.Descricao,
                            UF = e.UF,
                            Cidade = e.Cidade,
                            Bairro = e.Bairro,
                            Rua = e.Rua,
                            Numero = e.Numero,
                            Complemento = e.Complemento,
                            Editar = false
                        }
                    }).ToList();

                return View("SolicitacoesCliente", solicitacoes);
            }
            finally
            {
                if (unit != null)
                    unit.Dispose();

                unit = null;
            }
        }

        [HttpGet]
        public ActionResult CadastroSolicitacao(int id)
        {
            UnitOfWork unit = null;
            try
            {
                unit = new UnitOfWork();
                Cliente bdCliente = unit.Cliente.FindById(id);
                if (bdCliente == null)
                {
                    ViewBag.Retorno = "Cliente não encontrado";
                    return RedirectToAction("Index", "Home");
                }

                List<ResumoEnderecoViewModel> enderecos = unit.Endereco.ConsultaPorPessoaId(bdCliente.Id)
                    .Select( e => new ResumoEnderecoViewModel()
                    {
                        IdEndereco = e.Id,
                        Descricao = e.Descricao                        
                    })
                    .ToList();
                if(enderecos == null || enderecos.Count == 0)
                {
                    ViewBag.Retorno = "Para incluir uma solicitação de orçamento, é necessário que o cliente tenha pelo menos um endereço cadastrado.";
                    return View("~/Cliente/CadastroCliente", bdCliente.Id);
                }

                CadastroSolicitacaoOrcamentoViewModel cadastroSolicitacao = new CadastroSolicitacaoOrcamentoViewModel()
                {
                    IdPessoa = bdCliente.Id,
                    NomePessoa = bdCliente.Nome,
                    Enderecos = enderecos
                };

                return View("CadastroSolicitacao", cadastroSolicitacao);

            }
            finally
            {
                if (unit != null)
                    unit.Dispose();

                unit = null;
            }
        }

        [HttpPost]
        public ActionResult GravarSolicitacao(GravarSolicitacaoViewModel viewModel)
        {
            UnitOfWork unit = null;
            try
            {
                unit = new UnitOfWork();
                Cliente bdCliente = unit.Cliente.FindById(viewModel.IdPessoa);
                if (bdCliente == null)
                {
                    ViewBag.Retorno = "Cliente não encontrado.";
                    return RedirectToAction("Index", "Home");
                }

                Endereco bdEndereco = unit.Endereco.FindById(viewModel.IdEndereco);
                if (bdEndereco == null)
                {
                    ViewBag.Retorno = "Endereço não encontrado.";
                    return RedirectToAction("CadastroSolicitacao", bdCliente.Id);
                }

                if (String.IsNullOrWhiteSpace(viewModel.Descricao))
                {
                    ViewBag.Retorno = "Descrição não informada.";
                    return RedirectToAction("CadastroSolicitacao", bdCliente.Id);
                }

                if (String.IsNullOrWhiteSpace(viewModel.Data))
                {
                    ViewBag.Retorno = "Data não informada.";
                    return RedirectToAction("CadastroSolicitacao", bdCliente.Id);
                }

                if (String.IsNullOrWhiteSpace(viewModel.Hora))
                {
                    ViewBag.Retorno = "Hora não informada.";
                    return RedirectToAction("CadastroSolicitacao", bdCliente.Id);
                }

                string[] partesData = viewModel.Data.Split('/');
                string[] partesHora = viewModel.Hora.Split(':');

                DateTime datahora = new DateTime(
                    Int32.Parse(partesData[2])
                    , Int32.Parse(partesData[1])
                    , Int32.Parse(partesData[0])
                    , Int32.Parse(partesHora[0])
                    , Int32.Parse(partesHora[1])
                    , Int32.Parse(partesHora[2]));

                SolicitacaoOrcamento bdSolicitacao = new SolicitacaoOrcamento()
                {
                    Pessoa_Id = bdCliente.Id,
                    Endereco_Id = bdEndereco.Id,
                    Descricao = viewModel.Descricao,
                    Data_Hora = datahora,
                    Status = "P"
                };

                unit.SolicitacaoOrcamento.Insert(bdSolicitacao);
                unit.Save();

                return RedirectToAction("DetalheSolicitacao", new { @id = bdSolicitacao.Id });
            }
            finally
            {
                if (unit != null)
                    unit.Dispose();

                unit = null;
            }
        }


        [HttpGet]
        public ActionResult DetalheSolicitacao(int id)
        {
            UnitOfWork unit = null;
            try
            {
                unit = new UnitOfWork();

                SolicitacaoOrcamento bdSolicitacao = unit.SolicitacaoOrcamento.FindById(id);
                if (bdSolicitacao == null)
                {
                    ViewBag.Retorno = "Solicitação de orçamento não encontrado.";
                    return RedirectToAction("Index", "Home");
                }

                Cliente bdCliente = unit.Cliente.FindById(bdSolicitacao.Pessoa_Id);
                if (bdCliente == null)
                {
                    ViewBag.Retorno = "Cliente não encontrado.";
                    return RedirectToAction("Index", "Home");
                }

                Endereco bdEndereco = unit.Endereco.FindById(bdSolicitacao.Endereco_Id);
                if (bdEndereco == null)
                {
                    ViewBag.Retorno = "Endereço não encontrado.";
                    return RedirectToAction("CadastroSolicitacao", bdCliente.Id);
                }

                List<OrcamentoViewModel> orcamentos = unit.Orcamento.ConsultaPorIdSolicitacao(bdSolicitacao.Id)
                    .OrderByDescending(o => o.Data_Hora_Emissao)
                    .Select(o => new OrcamentoViewModel()
                    {
                        Id = o.Id,
                        IdSolicitacao = o.Solicitacao_Orcamento_Id,
                        DataHoraEmissao = o.Data_Hora_Emissao,
                        TempoEstimado = o.Tempo_Estimado,
                        ValorTotal = o.Valor_Total,
                        FormaPagamento = o.Forma_Pagamento,
                        Garantia = o.Garantia,
                        Status = o.Status,
                        Observacao = o.Observacao
                    })
                    .ToList();


                // TODO -> Adicionar listagem de serviços

                SolicitacaoOrcamentoViewModel solicitacao = new SolicitacaoOrcamentoViewModel()
                {
                    IdSolicitacao = bdSolicitacao.Id,
                    

                    IdPessoa = bdCliente.Id,
                    NomeCliente = bdCliente.Nome,

                    DataHoraSolicitacao = bdSolicitacao.Data_Hora,
                    DescricaoSolicitacao = bdSolicitacao.Descricao,

                    Endereco = new EnderecoViewModel()
                    {
                        Id = bdEndereco.Id,
                        IdPessoa = bdEndereco.Pessoa_Id,
                        Descricao = bdEndereco.Descricao,
                        UF = bdEndereco.UF,
                        Cidade = bdEndereco.Cidade,
                        Bairro = bdEndereco.Bairro,
                        Rua = bdEndereco.Rua,
                        Numero = bdEndereco.Numero,
                        Complemento = bdEndereco.Complemento,
                        Editar = false
                    },

                    Orcamentos = orcamentos
                };

                return View("DetalheSolicitacao", solicitacao);
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