using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            List<User> list = new List<User>();
            list.Add(new User { Id = 1, Name = "Gamotera", Position = "Developer" });
            list.Add(new User { Id = 2, Name = "Vinicius", Position = "Driver" });

            return View(list);
        }
    }
}
