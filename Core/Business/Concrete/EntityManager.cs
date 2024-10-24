using Core.Business.Abstract;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Concrete
{
    public class EntityManager<TEntity> : IEntityService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly IBaseRepository<TEntity> _repository;

        public EntityManager(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.Get(filter);
        }
    }
}
