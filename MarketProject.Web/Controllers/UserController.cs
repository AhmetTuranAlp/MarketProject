using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketProject.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            this.userService = _userService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}