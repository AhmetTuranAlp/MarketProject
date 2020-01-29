using MarketProject.Data.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarketProject.Data.ViewModel
{
    public class ProductEditVM
    {
        public ProductEditVM()
        {
            Product = new Product();
            CategoryList = new List<SelectListItem>();
        }
        public Product Product { get; set; }
        public List<SelectListItem> CategoryList { get; set; }
    }
}
