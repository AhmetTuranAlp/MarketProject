using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

    }
}
