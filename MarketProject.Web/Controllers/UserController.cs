using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Common;
using MarketProject.Data.Context;
using MarketProject.Data.Model;
using MarketProject.Data.Repositories;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace MarketProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Username, string Password)
        {
            User user = _userService.Login(Username, Password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id.ToString());
                return Json(true);
            }
            else
            {
                return Json(false);
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Username, string Password)
        {
            User user = new User()
            {
                Name = Username,
                Password = Password,
                Phone = "3242342",
                Status = ModelEnums.Status.Active,
                Surname = Username,
                UserName = Username,
                UpdateDate = DateTime.Now,
                UploadDate = DateTime.Now
            };
          
            if (_userService.Create(user))
            {
                User userlogin = _userService.Login(Username, Password);
                if (userlogin != null)
                {
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
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
}