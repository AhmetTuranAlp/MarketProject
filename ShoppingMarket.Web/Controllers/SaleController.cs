﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingMarket.Service.Base;

namespace ShoppingMarket.Web.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IBasketService _basketService;

        public SaleController(ISaleService saleService, IBasketService basketService)
        {
            _saleService = saleService;
            _basketService = basketService;
        }
        public IActionResult List()
        {
            return View();
        }
    }
}