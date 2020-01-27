using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Data.Model
{
    public class Sales : Base
    {
        public Sales()
        {
            TotalPrice = 0;
            BasketInformation = new List<Basket>();
        }

        private decimal _totalPrice;
        [Required(ErrorMessage = "Zorunlu Alan")]
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = Math.Round(value, 2); }
        }

        public PaymentType PaymentType { get; set; }
        public List<Basket> BasketInformation { get; set; }
    }
}
