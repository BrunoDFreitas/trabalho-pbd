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
                    unit = new UnitOfWork();
                    Cliente bdCliente = unit.Cliente.FindById(id);
                    if(bdCliente != null)
                    {
                        cliente.Id = bdCliente.Id;
                        cliente.CPFCNPJ = bdCliente.CPF_CNPJ;
                        cliente.Nome = bdCliente.Nome;
                        cliente.Ramo = bdCliente.Ramo;
                    }

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
                ViewBag.Erro = "";

                if (String.IsNullOrWhiteSpace(cliente.CPFCNPJ))
                {
                    ViewBag.Erro += "Informe o CPF/CNPJ do cliente.\n";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(cliente.Nome))
                {
                    ViewBag.Erro += "Informe o nome do cliente.\n";
                    dadosInvalidos = true;
                }

                if (String.IsNullOrWhiteSpace(cliente.Ramo))
                {
                    ViewBag.Erro += "Informe o ramo do cliente.\n";
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

                return RedirectToAction("Index");
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