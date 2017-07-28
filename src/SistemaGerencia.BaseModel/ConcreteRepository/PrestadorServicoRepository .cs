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
    public class PrestadorServicoRepository : GenericRepository<PrestadorServico>
    {
        public PrestadorServicoRepository(UnitOfWork unit) : base(unit)
        { }
        
        

        public IQueryable<PrestadorServico> ConsultaTodosPrestadoresServico()
        {
            return dbSet;
        }
    }
}
