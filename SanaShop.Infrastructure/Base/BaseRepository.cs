using SanaShop.Domain.Base;
using SanaShop.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Infrastructure.Base
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
        where TContext : AppDbContext
    {
        protected readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
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
