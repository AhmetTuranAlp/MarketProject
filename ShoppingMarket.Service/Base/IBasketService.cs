using ShoppingMarket.Common.Interfaces;
using ShoppingMarket.DTO.Common;
using ShoppingMarket.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Service.Base
{
    public interface IBasketService : IService<BasketDTO>, IMapper
    {
        List<BasketDTO> GetAll();
        Response<BasketDTO> GetBasket(int userId, int productId);
    }
}
