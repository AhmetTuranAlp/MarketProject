using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Data.Model
{
    public class Product : Base
    {
        public Product()
        {
            Name = "";
            Stock = 0;
            Price = 0;
        }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string ProductType { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Stock { get; set; }

        private decimal _price;
        [Required(ErrorMessage = "Zorunlu Alan")]
        public decimal Price
        {
            get { return _price; }
            set { _price = Math.Round(value, 2); }
        }
    }
}
