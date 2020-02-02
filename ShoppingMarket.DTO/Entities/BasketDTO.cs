using ShoppingMarket.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.DTO.Entities
{
    public class BasketDTO : Base
    {
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set { _price = Math.Round(value, 2); }
        }

        public int Quantity { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string UserCode{ get; set; }
    }
}
