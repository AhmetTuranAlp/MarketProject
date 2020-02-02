using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.Common.Interfaces
{
    public interface IMapper
    {
        T Map<T>(object objectToMap);
    }
}
