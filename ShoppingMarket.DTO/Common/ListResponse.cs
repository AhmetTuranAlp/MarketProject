using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.DTO.Common
{
    public class ListResponse<T> : Response<T>
    {
        public int TotalCount { get; set; }
    }
}
