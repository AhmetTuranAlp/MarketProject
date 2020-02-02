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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBasketService _basketService;
        public UserController(IUserService userService, IBasketService basketService)
        {
            _userService = userService;
            _basketService = basketService;
        }

        public ActionResult Login()
        {
            UserDTO user = new UserDTO();
            return View(user);
        }

        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                var result = _userService.Login(user.UserName, user.Password);
                if (result.Result != null && result.IsSuccess)
                {
                    HttpContext.Session.SetString("UserId", result.Result.Id.ToString());
                    List<BasketDTO> baskets = _basketService.GetAll().Where(x => x.Status == Status.Active && x.UserCode == this.HttpContext.Session.GetString("UserId")).ToList();
                    HttpContext.Session.Set<List<BasketDTO>>("BasketCard", baskets);



                    return RedirectToAction("List", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Giriş Yapılamadı. Lütfen Bilgilerinizi Kontrol Ederek Tekrar Deneyiniz.");
                    return View(user);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(user.UserName))
                {
                    ModelState.AddModelError("UserName", "Kullanıcı Adı Alanı Doldurulması Gerekmetedir.");
                }
                if (string.IsNullOrEmpty(user.Password))
                {
                    ModelState.AddModelError("Password", "Şifre Alanı Doldurulması Gerekmetedir.");
                }
                return View(user);
            }      
        }

        public ActionResult Register()
        {
            UserDTO user = new UserDTO();
            return View(user);
        }

        [HttpPost]
        public ActionResult Register(UserDTO user)
        {
            if (!string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.Email))
            {
                var result = _userService.Create(user);
                if (result.Result != null && result.IsSuccess)
                {
                    HttpContext.Session.SetString("UserId", result.Result.Id.ToString());
                    List<BasketDTO> baskets = _basketService.GetAll().Where(x => x.Status == Status.Active && x.UserCode == this.HttpContext.Session.GetString("UserId")).ToList();
                    HttpContext.Session.Set<List<BasketDTO>>("BasketCard", baskets);
                    return RedirectToAction("List", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Kayıt Olma İşlemi Başarısız. Lütfen Tekrar Deneyiniz.");
                    return View(user);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(user.UserName))             
                    ModelState.AddModelError(nameof(user.UserName), "Kullanıcı Adı Alanı Doldurulması Gerekmetedir.");
             
                if (string.IsNullOrEmpty(user.Password))              
                    ModelState.AddModelError(nameof(user.Password), "Şifre Alanı Doldurulması Gerekmetedir.");

                if (string.IsNullOrEmpty(user.Email))
                {
                    if (string.IsNullOrEmpty(user.Email))
                        ModelState.AddModelError(nameof(user.Email), "Email Alanı Doldurulması Gerekmetedir.");
                }
                else
                {
                    if (!user.Email.Contains("@"))
                        ModelState.AddModelError(nameof(user.Email), "Girilen değer email olmalıdır!");
                }    
                return View(user);
            }
        }
    }
}