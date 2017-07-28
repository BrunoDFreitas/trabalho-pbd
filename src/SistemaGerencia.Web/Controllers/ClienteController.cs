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
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            UnitOfWork unit = null;
            try
            {
                unit = new UnitOfWork();

                List<ClienteViewModel> clientes = unit.Cliente.ConsultaTodosClientes()
                    .Select(c => new ClienteViewModel()
                    {
                        Id = c.Id,
                        CPFCNPJ = c.CPF_CNPJ,
                        Nome = c.Nome,
                        Ramo = c.Ramo
                    }).ToList();

                return View(clientes);
            }
            finally
            {
                if(unit != null)
                {
                    unit.Dispose();
                }
                unit = null;
            }            
        }

        public ActionResult CadastroCliente(int id = 0)
        {
            UnitOfWork unit = null;
            try
            {
                ClienteViewModel cliente = new ClienteViewModel();
                if(id != 0)
                {
                    cliente.CarregaDadosCliente(id);
                }

                return View(cliente);
            }
            finally
            {
                if(unit != null)
                {
                    unit.Dispose();
                }
                unit = null;
            }
        }

        public ActionResult GravarCliente(ClienteViewModel cliente)
        {
            UnitOfWork unit = null;
            try
            {
                bool dadosInvalidos = false;
                ViewBag.Retorno = "";

                if (String.IsNullOrWhiteSpace(cliente.CPFCNPJ))
                {
                    ViewBag.Retorno += "Informe o CPF/CNPJ do cliente.\n";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(cliente.Nome))
                {
                    ViewBag.Retorno += "Informe o nome do cliente.\n";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(cliente.Ramo))
                {
                    ViewBag.Retorno += "Informe o ramo do cliente.\n";
                    dadosInvalidos = true;
                }

                if(dadosInvalidos)
                {
                    return View("CadastroCliente", cliente);
                }

                unit = new UnitOfWork();
                Cliente bdCliente = null;

                bool novoCliente = false;
                if (cliente.Id != 0)
                {
                    bdCliente = unit.Cliente.FindById(cliente.Id);
                }

                if(bdCliente == null)
                {
                    bdCliente = new Cliente();
                    novoCliente = true;
                }

                

                bdCliente.CPF_CNPJ = String.IsNullOrWhiteSpace(bdCliente.CPF_CNPJ) ? cliente.CPFCNPJ : bdCliente.CPF_CNPJ;
                bdCliente.Nome = cliente.Nome;
                bdCliente.Ramo = cliente.Ramo;
                bdCliente.Fisico_Juridico = bdCliente.CPF_CNPJ.Trim().Length > 11 ? "J" : "F";

                if (novoCliente)
                {
                    unit.Cliente.Insert(bdCliente);
                }
                else
                {
                    unit.Cliente.Update(bdCliente);                    
                }
                unit.Save();

                if (novoCliente)
                {
                    ViewBag.Retorno = "Cliente cadastrado com sucesso.";
                }
                else
                {
                    ViewBag.Retorno = "Cadastro do cliente atualizado com sucesso.";
                }

                cliente.CarregaDadosCliente(bdCliente.Id);

                return View("CadastroCliente", cliente);
            }
            finally
            {
                if (unit != null)
                    unit.Dispose();

                unit = null;
            }
        }


        public ActionResult GravarEndereco(EnderecoViewModel endereco)
        {
            UnitOfWork unit = null;
            try
            {
                
                if(endereco.IdPessoa <= 0)
                {
                    ViewBag.Retorno = "Erro ao cadastro novo endereço. Id do cliente não informado.";
                    return View("Index");
                }

                unit = new UnitOfWork();
                Cliente bdCliente = unit.Cliente.FindById(endereco.IdPessoa);
                if(bdCliente == null)
                {
                    ViewBag.Retorno = "Erro ao cadastro novo endereço. Cliente não encontrado.";
                    return View("Index");
                }

                ClienteViewModel cliente = new ClienteViewModel();

                bool dadosInvalidos = false;
                ViewBag.Retorno = "";

                if (String.IsNullOrWhiteSpace(endereco.Descricao))
                {
                    ViewBag.Retorno += "Descrição do endereço não informado.";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(endereco.UF))
                {
                    ViewBag.Retorno += "UF do endereço não informado.";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(endereco.Cidade))
                {
                    ViewBag.Retorno += "Cidade do endereço não informado.";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(endereco.Bairro))
                {
                    ViewBag.Retorno += "Bairro do endereço não informado.";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(endereco.Rua))
                {
                    ViewBag.Retorno += "Rua do endereço não informado.";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(endereco.Numero))
                {
                    ViewBag.Retorno += "Número do endereço não informado.";
                    dadosInvalidos = true;
                }

                if(dadosInvalidos)
                {
                    return View("CadastroCliente", cliente.CarregaDadosCliente(endereco.IdPessoa));
                }

                Endereco bdEndereco = new Endereco()
                {
                    Pessoa_Id = endereco.IdPessoa,
                    Descricao = endereco.Descricao,
                    UF = endereco.UF,
                    Cidade = endereco.Cidade,
                    Bairro = endereco.Bairro,
                    Rua = endereco.Rua,
                    Numero = endereco.Numero,
                    Complemento = endereco.Complemento
                };

                unit.Endereco.Insert(bdEndereco);
                unit.Save();

                ViewBag.Retorno = "Endereço gravado com sucesso.";

                return View("CadastroCliente", cliente.CarregaDadosCliente(endereco.IdPessoa));

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