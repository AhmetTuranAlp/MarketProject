using MarketProject.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Service.Interfaces
{
    public interface IProductService : IService<Product>
    {
        Product CreateApi(Product product);
    }
}
