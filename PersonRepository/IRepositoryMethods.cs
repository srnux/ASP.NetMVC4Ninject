using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonRepository
{
    public interface IRepositoryMethods<T> : IDisposable
    {
        IQueryable<T> All { get; }
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        T Find(long id);
        void InsertOrUpdate(T accesslevel);
        void Delete(long id);
        void Save();
    }
}
