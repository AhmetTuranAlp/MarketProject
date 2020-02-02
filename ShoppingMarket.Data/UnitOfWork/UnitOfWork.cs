using ShoppingMarket.Data.Context;
using ShoppingMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingMarket.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ShoppingMarketDbContext _dbContext;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(ShoppingMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {

            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }
            else
            {
                IRepository<T> repo = new EFRepository<T>(_dbContext);
                _repositories.Add(typeof(T), repo);
                return repo;
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }


        public virtual Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        #endregion

        #region IDisposable Members
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                    _repositories = null;
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
