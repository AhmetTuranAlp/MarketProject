using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Common;
using MarketProject.Data.Model;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ISalesService _salerService;
        public BasketController(IBasketService basketService, ISalesService salesService)
        {
            _basketService = basketService;
            _salerService = salesService;
        }
        public IActionResult Index()
        {
            return View(_basketService.GetAll().Where(x => x.Status != Status.Deleted && x.UserId == Convert.ToInt32(this.HttpContext.Session.GetString("UserId"))).ToList());
        }

        [HttpPost]
        public ActionResult CompleteShopping(string id)
        {
            try
            {
                List<Basket> baskets = _basketService.GetAll().Where(x => x.Status != Status.Deleted && x.UserId == Convert.ToInt32(this.HttpContext.Session.GetString("UserId"))).ToList();

                EnumHelper enumHelper = new EnumHelper();
                Sales sales = new Sales()
                {
                    PaymentType = enumHelper.GetEnumDescription(PaymentType.CreditCardOnline),
                    Status = Status.Active,
                    UploadDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                };

                baskets.ForEach(x =>
                {
                    if (x.Quantity > 1)
                    {
                        for (int i = 0; i < x.Quantity; i++)
                        {
                            sales.TotalPrice += x.Price;
                        }
                    }
                    else
                    {
                        sales.TotalPrice += x.Price;
                    }
              
                    x.Status = Status.Deleted;
                    _basketService.Update(x);
                });

                if (_salerService.Create(sales))
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