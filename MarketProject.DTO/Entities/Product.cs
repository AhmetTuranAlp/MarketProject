using System;
using System.Collections.Generic;
using System.Text;
using static MarketProject.DTO.Entities.ModelEnums;

namespace MarketProject.DTO.Entities
{
    public class Product : Base
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}
