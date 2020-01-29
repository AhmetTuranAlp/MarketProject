﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Common;
using MarketProject.Data.Model;
using MarketProject.Data.ViewModel;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static MarketProject.Data.Model.ModelEnums;

namespace MarketProject.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(_productService.GetAll().Where(x=>x.Status !=  Status.Deleted).ToList());
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
                    ProductType = enumHelper.IntToEnumName<ProductType>(Convert.ToInt32(category)),
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
                    ProductEditVM productEditVM = new ProductEditVM();
                    product.ProductType = enumHelper.StringToEnumValue<PaymentType>(product.ProductType).ToString();
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

                throw;
            }
        }

    }
}