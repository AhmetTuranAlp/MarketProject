using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ShoppingMarket.DTO.Entities
{
   public class ModelEnums
    {
        public enum Status : int
        {
            [Description("Silindi")]
            Deleted = 0,
            [Description("Aktif")]
            Active = 1,
            [Description("Pasif")]
            Passive = 2,
            [Description("Yeni Kayıt")]
            NewRecord = 3
        }

        public enum CurrencyType
        {
            [Description("TL")]
            TL = 0,
            [Description("USD")]
            USD = 1,
            [Description("EURO")]
            EURO = 2,
        }

    }
}
