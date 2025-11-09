using SanaShop.Domain.Base;
using SanaShop.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Base
{
    public class BaseService<TRepository, TEntity> : IBaseService<TEntity>
        where TRepository : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly TRepository _repository;
        public BaseService(TRepository repository)
        {
            _repository = repository;
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
