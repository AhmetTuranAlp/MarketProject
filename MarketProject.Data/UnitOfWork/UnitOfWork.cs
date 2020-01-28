using MarketProject.Data.Context;
using MarketProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MarketProjectDbContext _dbContext;
        private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();


        public UnitOfWork(MarketProjectDbContext dbContext)
        {
            //Database.SetInitializer<SuperMarketProjectDbContext>(null);
            _dbContext = dbContext;
        }

        #region IUnitOfWork Members
        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(_dbContext);
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

