using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarketProject.Data;
using MarketProject.Data.Context;

namespace MarketProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(MarketProjectDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            TEntity entity = _dbSet.Find(id);
            Delete(entity);
        }

        public TEntity Find(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
