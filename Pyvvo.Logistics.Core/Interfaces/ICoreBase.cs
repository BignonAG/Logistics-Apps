using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Pyvvo.Logistics.Core
{
    public interface ICoreBase<T> where T : class
    {
          Task<T> Get(long id);
          Task<Boolean> Create(T entity);   
          Task<Boolean> Update(T entity);
          Task<Boolean> Delete(long id);
          Task<List<T>> GetList(Expression<Func<T, bool>> predicate, string QueryParam);

    }
}