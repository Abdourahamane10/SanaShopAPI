using SanaShop.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Base
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where);
    }
}
