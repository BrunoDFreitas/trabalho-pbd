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
    public class SolicitacaoOrcamentoRepository : GenericRepository<SolicitacaoOrcamento>
    {
        public SolicitacaoOrcamentoRepository(UnitOfWork unit) : base(unit)
        {
        }

        public IQueryable<SolicitacaoOrcamento> ConsultaPorIdPessoa(int idPessoa)
        {
            return dbSet.Where(s => s.Pessoa_Id == idPessoa);
        }
    }
}
