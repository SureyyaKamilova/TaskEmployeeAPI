using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseEntityRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using var context=new TContext();
            var addedEntiry=context.Entry(entity);
            addedEntiry.State = EntityState.Added;
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using var context = new TContext();
            var removeEntry=context.Remove(entity);
            removeEntry.State = EntityState.Deleted;
            context.SaveChanges();
        }
        
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new TContext();
            return context.Set<TEntity>().OrderBy(entity => entity).LastOrDefault(filter);
        }

        public void Update(TEntity entity)
        {
            using var context = new TContext();
            var updateEntry=context.Entry(entity);
            updateEntry.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
