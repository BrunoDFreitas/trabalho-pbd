﻿using SistemaGerencia.BaseModel.Model;
using SistemaGerencia.BaseModel.Repository;
using SistemaGerencia.BaseModel.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.ConcreteRepository
{
    public class OrcamentoRespository : GenericRepository<Orcamento>
    {
        public OrcamentoRespository(UnitOfWork unit) : base(unit)
        {
        }

        public IQueryable<Orcamento> ConsultaPorIdSolicitacao(int idSolicitacao)
        {
            return dbSet.Where(s => s.Solicitacao_Orcamento_Id == idSolicitacao);
        }
    }
}
