﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.DTO.Entities
{
    public class Basket : Base
    {
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
