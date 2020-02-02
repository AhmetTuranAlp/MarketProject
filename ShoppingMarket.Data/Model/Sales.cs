using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingMarket.Data.Model
{
    public class Sales : Base
    {
        public Sales()
        {
            TotalPrice = 0;
   
        }

        private decimal _totalPrice;
        [Required(ErrorMessage = "Zorunlu Alan")]
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
