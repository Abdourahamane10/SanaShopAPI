using SanaShop.Applications.Base;
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
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        #region Propriétés protégées

        protected readonly SanaShopDbContext _context;

        #endregion Propriétés protégées

        #region Constructeurs
        public BaseRepository(SanaShopDbContext context)
        {
            _context = context;
        }
        #endregion Constructeurs

        #region Implémentation de IBaseRepository<TEntity>
        public async Task AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
        #endregion Implémentation de IBaseRepository<TEntity>
    }
}
