using ShoppingMarket.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingMarket.DTO.Entities
{
    public class SalesDTO :Base
    {
        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = Math.Round(value, 2); }
        }

        public string PaymentType { get; set; }

        public string UserName { get; set; }

        public string UserCode { get; set; }

        public int TotalQuantity { get; set; }
    }
}
