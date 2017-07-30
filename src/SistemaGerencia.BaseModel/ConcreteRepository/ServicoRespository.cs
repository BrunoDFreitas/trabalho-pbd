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
    public class ServicoRespository : GenericRepository<Servico>
    {
        public ServicoRespository(UnitOfWork unit) : base(unit)
        {
        }

        public IQueryable<Servico> ConsultaPorIdOrcamento(int idOrcamento)
        {
            return dbSet.Where(o => o.Orcamento_Id == idOrcamento);
        }
        
    }
}
