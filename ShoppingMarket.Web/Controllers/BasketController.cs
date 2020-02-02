using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingMarket.DTO.Entities;
using ShoppingMarket.Service.Base;
using ShoppingMarket.Web.Headers;
using static ShoppingMarket.DTO.Entities.ModelEnums;

namespace ShoppingMarket.Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;
        private readonly IBasketService _basketService;

        public BasketController(ISaleService saleService, IBasketService basketService, IProductService productService, IUserService userService)
        {
            _saleService = saleService;
            _basketService = basketService;
            _productService = productService;
            _userService = userService;
        }
        public IActionResult List()
        {
            var userId = this.HttpContext.Session.GetString("UserId");
            var basketDTO = _basketService.GetAll().Where(x => x.UserCode == userId).ToList();
            return View(basketDTO);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var basket = _basketService.Get(id);
                if (basket.Result != null && basket.IsSuccess)
                {
                    basket.Result.Status = Status.Deleted;
                    var result = _basketService.Update(basket.Result);
                    if (result.IsSuccess)
                    {
                        List<BasketDTO> basketsSession = _basketService.GetAll().Where(x => x.Status == Status.Active && x.UserCode == this.HttpContext.Session.GetString("UserId")).ToList();
                        HttpContext.Session.Set<List<BasketDTO>>("BasketCard", basketsSession);
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
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
        public ActionResult CompleteShopping()
        {
            try
            {
                var userId = this.HttpContext.Session.GetString("UserId");
                var baskets = _basketService.GetAll().Where(x => x.UserCode == userId).ToList();

                #region Ödeme Modeline Bilgiler Set Ediliyor.
                SalesDTO sales = new SalesDTO()
                {
                    Status = Status.Active,
                    UploadDate = DateTime.Now,
                    UpdateDate = DateTime.Now,

                };
                #endregion

                baskets.ForEach(x =>
                {
                    #region Ürün Stok Bilgisi Güncelleniyor.
                    var product = _productService.GetAll().Where(c => c.ProductId == x.ProductCode).FirstOrDefault();
                    if (product != null)
                    {
                        product.Stock -= x.Quantity;
                        var res = _productService.Update(product);
                    }
                    #endregion

                    #region Sepetdeki Ürün Satış İşleminden Dolayı Statusu Silindiye Çekiliyor.
                    x.Status = Status.Deleted;
                    _basketService.Update(x);
                    #endregion

                    #region Ödeme Modeline Bilgiler Set Ediliyor.
                 
                    if (x.Quantity > 1)
                    {
                        for (int i = 0; i < x.Quantity; i++)
                        {
                            sales.TotalPrice += x.Price;
                        }
                    }
                    else
                    {
                        sales.TotalPrice = x.Price;
                    }

                    sales.PaymentType = "Kredi Kartı (Tek Çekim)";
                    sales.TotalQuantity += x.Quantity;
                    sales.UserCode = userId;

                    var userDto = _userService.Get(Convert.ToInt32(userId));
                    if (userDto.IsSuccess)
                    {
                        sales.UserName = userDto.Result.UserName;
                    }
                   
                    #endregion
                });
              

                var result = _saleService.Create(sales);
                if (result.Result != null && result.IsSuccess)
                {
                    #region Sepet Session'ı Güncelleniyor.
                    List<BasketDTO> basketsSession = _basketService.GetAll().Where(x => x.Status == Status.Active && x.UserCode == this.HttpContext.Session.GetString("UserId")).ToList();
                    HttpContext.Session.Set<List<BasketDTO>>("BasketCard", basketsSession);
                    return Json(true); 
                    #endregion
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