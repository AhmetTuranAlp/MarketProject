using ShoppingMarket.Common.Interfaces;
using ShoppingMarket.DTO.Common;
using ShoppingMarket.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Service.Base
{
    public interface IProductService : IService<ProductDTO>, IMapper
    {
        List<ProductDTO> GetAll();

        Response<ProductDTO> CreateApi(ProductDTO product);

    }
}
