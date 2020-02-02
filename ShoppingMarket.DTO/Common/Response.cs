using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.DTO.Common
{
    public class Response<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }
    }
}
