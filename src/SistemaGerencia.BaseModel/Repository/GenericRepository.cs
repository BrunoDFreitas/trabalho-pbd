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
        internal DbContext context;


        public GenericRepository(UnitOfWork unit)
        {
            dbSet = unit.Context.Set<TEntity>();
            context = unit.Context;
        }

        public virtual IQueryable<TEntity> All()
        {
            return dbSet.AsQueryable<TEntity>();
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual TEntity FindById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }        

        public virtual void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
