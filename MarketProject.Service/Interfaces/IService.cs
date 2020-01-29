using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        bool Create(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(int id);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

    }
}
