using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Controllers
{
    public class HomeController : Controller
    {
        CarContext context;
        public HomeController(CarContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string thanks = "")
        {
            
            if (!string.IsNullOrEmpty(thanks))
                ViewBag.Thanks = thanks;
            var cars = context.Cars.ToList();
            return View(cars);
        }


        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return RedirectToAction("Index",new { thanks= "Thank you for purchase!" });
        }
    }
}
