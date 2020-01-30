using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Data.Model;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Web.Views.Product
{
    public class SalesController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ISalesService _salerService;
        public SalesController(IBasketService basketService, ISalesService salesService)
        {
            _basketService = basketService;
            _salerService = salesService;
        }
        public IActionResult Index()
        {
            int salesMax = _salerService.GetAll().Where(x => x.Status == ModelEnums.Status.Active).ToList().Max(v=>v.Id);
            return View(_salerService.Get(salesMax));
        }
    }
}