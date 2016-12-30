using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.Repository
{
    public interface IRepositoryAsync<T> : IRepository<T> where T : class
    {
        Task<T> FindAsync(params object[] keyValues);
      
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    }
}
