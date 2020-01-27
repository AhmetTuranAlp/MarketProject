using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketProject.Data.Model
{
    public class Basket : Base
    {
        public Basket()
        {
            Price = 0;
            Quantity = 0;
            ProductName = "";
        }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int UserId { get; set; }

        private decimal _price;
        [Required(ErrorMessage = "Zorunlu Alan")]
        public decimal Price
        {
            get { return _price; }
            set { _price = Math.Round(value, 2); }
        }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string ProductName { get; set; }

    }
}
