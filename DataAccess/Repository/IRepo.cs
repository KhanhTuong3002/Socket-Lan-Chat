using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepo<T, in TKey>
    {
        T? this[TKey id] { get; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> GetAll();
    }

    public interface IRepo<T> : IRepo<T, int>
    {
    }
}
