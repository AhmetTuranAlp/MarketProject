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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        public ProductController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public ActionResult List()
        {
            return View(_productService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductDTO product)
        {
            try
            {
                if (product != null)
                {
                    var result = _productService.Create(product);
                    if (result.Result != null && result.IsSuccess)
                    {
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

        [Route("ProductEdit/{id}")]
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _productService.Get(id);
                if (result.Result != null && result.IsSuccess)
                {
                    return View(result.Result);
                }
                else
                {
                    return View(new ProductDTO());
                }
            }
            catch (Exception)
            {
                return View(new ProductDTO());
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductDTO product)
        {
            try
            {
                if (product != null)
                {
                    var result = _productService.Update(product);
                    if (result.Result != null && result.IsSuccess)
                    {
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

        public ActionResult BasketAdd(int id)
        {
            try
            {
                var product = _productService.Get(id);
                if (product.Result != null && product.IsSuccess)
                {
                    var basketProduct = _basketService.GetBasket(Convert.ToInt32(this.HttpContext.Session.GetString("UserId")), Convert.ToInt32(product.Result.ProductId));
                    if (basketProduct.Result != null)
                    {
                        basketProduct.Result.Quantity += 1;
                        if (product.Result.Stock >= basketProduct.Result.Quantity)
                        {
                            var result = _basketService.Update(basketProduct.Result);
                            if (result.Result != null && result.IsSuccess)
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
                    else
                    {
                        if (product.Result.Stock > 0)
                        {
                            BasketDTO basketDTO = new BasketDTO()
                            {
                                Price = product.Result.SalePrice,
                                Status = Status.Active,
                                ProductName = product.Result.Name,
                                Quantity = 1,
                                UpdateDate = DateTime.Now,
                                UploadDate = DateTime.Now,
                                UserCode = this.HttpContext.Session.GetString("UserId"),
                                ProductCode = product.Result.ProductId
                            };

                            var result = _basketService.Create(basketDTO);
                            if (result.Result != null && result.IsSuccess)
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
        public ActionResult ProductDelete(int id)
        {
            try
            {
                var product = _productService.Get(id);
                if (product.Result != null && product.IsSuccess)
                {
                    product.Result.Status = Status.Deleted;
                    var result = _productService.Update(product.Result);
                    if (result.IsSuccess)
                    {
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
    }
}