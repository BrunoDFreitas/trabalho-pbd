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
    }
}