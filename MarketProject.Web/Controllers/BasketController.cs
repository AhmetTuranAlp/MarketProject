using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public IActionResult Index()
        {
            return View(_basketService.GetAll().Where(x => x.Status != Status.Deleted).ToList());
        }

        [HttpPost]
        public ActionResult BasketDelete(string id)
        {
            try
            {
                if (_basketService.Delete(Convert.ToInt32(id)))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}