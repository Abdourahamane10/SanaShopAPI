using Microsoft.EntityFrameworkCore.Storage;
using SanaShop.Applications.Interfaces;
using SanaShop.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Infrastructure.UnitOfWork
{
    public class EfUnitOfWork : IUnitOfWork
    {
        #region Attributs

        private readonly SanaShopDbContext _context;
        private IDbContextTransaction? _transaction;

        #endregion Attributs

        #region Constructeurs
        public EfUnitOfWork(SanaShopDbContext context)
        {
            _context = context;
        }
        #endregion Constructeurs
        public async Task BeginTransactionAsync()
        {
            _transaction =  await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction!.CommitAsync();
            await _transaction.DisposeAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction!.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
           return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
