using SistemaGerencia.BaseModel.Model;
using SistemaGerencia.BaseModel.Repository;
using SistemaGerencia.BaseModel.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.ConcreteRepository
{
    public class ClienteRepository : GenericRepository<Cliente>
    {
        public ClienteRepository(UnitOfWork unit) : base(unit)
        { }
        
        

        public IQueryable<Cliente> ConsultaTodosClientes()
        {
            return dbSet;
        }
    }
}
