using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingMarket.Data.Model
{
    public class Basket : Base
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


        public string UserCode { get; set; }

    }
}
