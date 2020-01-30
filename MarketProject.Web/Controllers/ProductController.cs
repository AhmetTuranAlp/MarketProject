using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Common;
using MarketProject.Data.Model;
using MarketProject.Data.VModel;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Web.Controllers
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
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            try
            {
                EnumHelper enumHelper = new EnumHelper();
                products = _productService.GetAll().Where(x => x.Status != Status.Deleted).ToList();
                products.ForEach(x =>
                {
                    x.ProductType = enumHelper.IntToEnumName<ProductType>(Convert.ToInt32(x.ProductType));
                });
                return View(products);
            }
            catch (Exception)
            {
                return View(products);
            }
        }

        public ActionResult ProductCreate()
        {
            EnumHelper enumHelper = new EnumHelper();
            List<SelectListItem> productCategory = new List<SelectListItem>();
            productCategory.Add(new SelectListItem() { Value = "", Text = "Kategori Seçiniz..." });
            productCategory.AddRange(enumHelper.GetEnumListWithDescription(typeof(ProductType)));
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult ProductCreate(string name, decimal price, int stock, string category)
        {
            try
            {
                EnumHelper enumHelper = new EnumHelper();
                Product product = new Product()
                {
                    Name = name,
                    Price = price,
                    ProductType = category,
                    Status = Status.Active,
                    Stock = stock,
                    UpdateDate = DateTime.Now,
                    UploadDate = DateTime.Now
                };

                if (_productService.Create(product))
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
        public ActionResult ProductDelete(int id)
        {
            try
            {
                if (_productService.Delete(id))
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


        [Route("ProductEdit/{id}")]
        public ActionResult ProductEdit(int id)
        {
            try
            {
                Product product = _productService.Get(id);
                if (product != null)
                {
                    EnumHelper enumHelper = new EnumHelper();
                    //product.ProductType = enumHelper.StringToEnumValue<PaymentType>(product.ProductType).ToString();
                    ProductEditVM productEditVM = new ProductEditVM();
                    productEditVM.Product = product;

                    productEditVM.CategoryList.Add(new SelectListItem() { Value = "", Text = "Kategori Seçiniz..." });
                    productEditVM.CategoryList.AddRange(enumHelper.GetEnumListWithDescription(typeof(ProductType)));
                    return View(productEditVM);
                }
                else
                {
                    return View(new ProductEditVM());
                }
            }
            catch (Exception)
            {
                return View(new ProductEditVM());
            }
        }

        [HttpPost]
        public ActionResult UpdateProduct(string Id, string name, decimal price, int stock, string category)
        {
            try
            {
                Product product = new Product()
                {
                    Id = Convert.ToInt32(Id),
                    Name = name,
                    Price = price,
                    ProductType = category,
                    Status = Status.Active,
                    Stock = stock,
                    UpdateDate = DateTime.Now,
                    UploadDate = DateTime.Now
                };

                if (_productService.Update(product))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult BasketAdd(string id)
        {
            try
            {
                Product product = _productService.Get(Convert.ToInt32(id));

                var baskets = _basketService.GetAll().Where(x => x.ProductId == product.Id && x.Status != Status.Deleted);
                if (baskets.Count() > 0)
                {
                    Basket basket = baskets.FirstOrDefault();
                    basket.Quantity += 1;
                    if (_basketService.Update(basket))
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
                    Basket basket = new Basket()
                    {
                        Price = product.Price,
                        Status = Status.NewRecord,
                        ProductName = product.Name,
                        Quantity = 1,
                        UpdateDate = DateTime.Now,
                        UploadDate = DateTime.Now,
                        UserId = Convert.ToInt32(this.HttpContext.Session.GetString("UserId")),
                        ProductId = product.Id
                    };
                    if (_basketService.Create(basket))
                    {
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }
                }

            }
            catch (Exception)
            {
                return Json(false);
            }
        }
    }
}