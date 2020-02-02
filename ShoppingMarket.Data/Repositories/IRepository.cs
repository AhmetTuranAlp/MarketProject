using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ShoppingMarket.Data.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);

        void Update(T entity);

        void Delete(object id);

        void Delete(T entity);

        IQueryable<T> GetAll();

        T Get(int id);

        T GetById(object obje);

        int GetCount(Expression<Func<T, bool>> filter = null);

        bool GetExists(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> Get(
           Expression<Func<T, bool>> filter = null,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
           string includeProperties = null,
           int? skip = null,
           int? take = null);

    }
}
