using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Data.Context;
using MarketProject.Data.Model;
using MarketProject.Data.Repositories;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            if (_userService.Login(Username, Password) != null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        
        }
    }
}