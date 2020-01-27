using System;
using System.Collections.Generic;
using System.Text;
using static MarketProject.DTO.Entities.ModelEnums;

namespace MarketProject.DTO.Entities
{
    public class Sales : Base
    {
        public decimal TotalPrice { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<Basket> BasketInformation { get; set; }
    }
}
