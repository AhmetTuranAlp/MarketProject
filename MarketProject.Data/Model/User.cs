using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarketProject.Data.Model
{
    public class User : Base
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Phone { get; set; }
    }
}
