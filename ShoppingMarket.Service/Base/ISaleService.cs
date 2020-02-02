using ShoppingMarket.Common.Interfaces;
using ShoppingMarket.DTO.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Service.Base
{
    public interface ISaleService : IService<SalesDTO>, IMapper
    {
        List<SalesDTO> GetAll();
    }
}
