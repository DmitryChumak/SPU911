using CandyShop.Models;
using CandyShop.Models.ViewModels;
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
        //public IActionResult Index(string thanks = "", SortType sortType = SortType.TitleAsc)
        //{

        //    if (!string.IsNullOrEmpty(thanks))
        //        ViewBag.Thanks = thanks;
        //    IEnumerable<Car> result = null;
        //    switch (sortType)
        //    {
        //        case SortType.TitleAsc:
        //            result = context.Cars.OrderBy(x => x.Title).ToList();
        //            break;
        //        case SortType.ModelAsc:
        //            result = context.Cars.OrderBy(x => x.Model).ToList();
        //            break;
        //        case SortType.PriceAsc:
        //            result = context.Cars.OrderBy(x => x.Price).ToList();
        //            break;
        //        default:
        //            result = context.Cars.ToList();
        //            break;
        //    }
        //    return View(result);
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CarsList(string search="", string company = "all")
        {
            var selectListItems = new List<string> { "all" };
            selectListItems.AddRange(context.Cars.Select(x => x.Title));
            var cars = company == "all" ? context.Cars.ToList()
                                        : context.Cars.Where(x => x.Title.ToLower() == company.ToLower()).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                cars = cars.Where(x => x.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            return PartialView(new CarListViewModel
            {
                Cars = cars,
                Companies = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(selectListItems)
            });
        }

        public IActionResult CarsJson()
        {
            return Json(context.Cars.ToList());
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
            if (order.User?.ToLower() == "andrey")
            {
                ModelState.AddModelError("User", "Андрей, уходиТЕ!");
                ModelState.AddModelError("KU", "Андрей, KU!");
            }
            if (ModelState.IsValid)
            {
                context.Orders.Add(order);
                context.SaveChanges();
                return RedirectToAction("Index", new { thanks = "Thank you for purchase!" });
            }
            else
            {
                return View(order);
            }
          
        }
    }
}
