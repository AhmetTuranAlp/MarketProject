using ShoppingMarket.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Service.Base
{
    public interface IService<T> where T : class
    {
        Response<T> Create(T entity);
        Response<T> Update(T entity);
        Response<T> Get(int id);
  
        Response<bool> Delete(int id);
    }
}
