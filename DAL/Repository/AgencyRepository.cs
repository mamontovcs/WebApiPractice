using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repository
{
    internal class AgencyRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AgencyContext Context;
        private readonly DbSet<TEntity> dataContext;


        public AgencyRepository(AgencyContext context)
        {
            Context = context;
            dataContext = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            using (AgencyContext db = new AgencyContext())
            {
                dataContext.Add(item);
            }
        }

        public TEntity FindById(int id)
        {
            return dataContext.Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return dataContext.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dataContext.AsNoTracking().Where(predicate).ToList();
        }

        public TEntity GetOne(Func<TEntity, bool> predicate)
        {
            return dataContext.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Remove(TEntity item)
        {
            try
            {
                dataContext.Remove(item);
            }
            catch (ArgumentNullException)
            {

            }
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

    }
}
