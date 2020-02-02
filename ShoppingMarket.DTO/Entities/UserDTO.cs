using ShoppingMarket.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingMarket.DTO.Entities
{
    public class UserDTO : Base
    {
        public UserDTO()
        {
            UserName = "";
            Password = "";
            Email = "";
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
