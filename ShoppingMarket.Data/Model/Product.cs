using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static ShoppingMarket.Data.Model.ModelEnums;

namespace ShoppingMarket.Data.Model
{
    public class Product : Base
    {

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }


        private decimal _marketPrice;
        [Required(ErrorMessage = "Zorunlu Alan")]
        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = Math.Round(value, 2); }
        }

        private decimal _salePrice;
        [Required(ErrorMessage = "Zorunlu Alan")]
        public decimal SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = Math.Round(value, 2); }
        }

        public decimal KDV { get; set; }
        public CurrencyType CurrencyType { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int Stock { get; set; }
    }
}
