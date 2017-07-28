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
    public class FornecedorRepository : GenericRepository<Fornecedor>
    {
        public FornecedorRepository(UnitOfWork unit) : base(unit)
        { }

        public IQueryable<Fornecedor> ConsultaTodosFornecedores()
        {
            //return dbSet.Where(p => p.Tipo_Pessoa == "F");
            return dbSet;
        }
    }
}
