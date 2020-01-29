using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Web.Views.Product
{
    public class SalesController : Controller
    {
        private readonly ISalesService _salesService;

        public SalesController(ISalesService salesService)
        {
            _salesService = salesService;
        }
        public IActionResult Index()
        {
            return View(_salesService.GetAll().Where(x=>x.Status != Data.Model.ModelEnums.Status.Deleted).ToList());
        }
    }
}