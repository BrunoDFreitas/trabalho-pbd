using SistemaGerencia.BaseModel.Unit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGerencia.BaseModel.Repository
{
    public abstract class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        internal DbSet<TEntity> dbSet;


        public GenericRepository(UnitOfWork unit)
        {
            dbSet = unit.Context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> All()
        {
            return dbSet.AsQueryable<TEntity>();
        }

        public virtual void Delete(TEntity t)
        {
            dbSet.Remove(t);
        }

        public virtual TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity t)
        {
            dbSet.Add(t);
        }
    }
}
