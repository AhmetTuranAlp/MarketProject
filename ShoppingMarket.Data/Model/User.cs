using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingMarket.Data.Model
{
    public class User : Base
    {
        public User()
        {
            UserName = "";
            Password = "";
            Email = "";
        }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Email { get; set; }
    }
}
