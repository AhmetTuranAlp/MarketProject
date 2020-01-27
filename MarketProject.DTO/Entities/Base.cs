using System;
using System.Collections.Generic;
using System.Text;
using static MarketProject.DTO.Entities.ModelEnums;

namespace MarketProject.DTO.Entities
{
   public class Base
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public  DateTime UploadDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
