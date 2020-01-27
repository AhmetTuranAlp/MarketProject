using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.DTO.Entities
{
    public class User :Base
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}
