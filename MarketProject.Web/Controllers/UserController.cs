using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Data.Repositories;
using MarketProject.DTO.Entities;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userService;
        public UserController(IRepository<User> userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string Username, string Password)
        {
            //User user = _userService.Login(Username, Password);
            return Json(true);
        }
    }
}