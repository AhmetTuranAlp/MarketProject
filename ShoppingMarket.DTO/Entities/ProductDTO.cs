using ShoppingMarket.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using static ShoppingMarket.DTO.Entities.ModelEnums;

namespace ShoppingMarket.DTO.Entities
{
    public class ProductDTO : Base
    {
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }


        private decimal _marketPrice;
        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = Math.Round(value, 2); }
        }

        private decimal _salePrice;
        public decimal SalePrice
        {
            get { return _salePrice; }
            set { _salePrice = Math.Round(value, 2); }
        }

        public decimal KDV { get; set; }
        public CurrencyType CurrencyType { get; set; }

        public int Stock { get; set; }
    }

}
