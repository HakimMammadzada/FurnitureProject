using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureProject.Controllers
{
    public class SubscribeController : Controller
    {
        public IActionResult Index()
        {
            int? count = HttpContext.Session.GetInt32("count");
            if (count!= null)
            {
                count++;
            }
            else
            {
                count = 1; 
            }
            HttpContext.Session.SetInt32("count", (int)count);
            return View(count);
        }
    }
}