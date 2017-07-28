using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.Repository
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> All();

        TEntity FindById(int id);

        void Insert(TEntity t);

        void Delete(TEntity t);
    }
}
