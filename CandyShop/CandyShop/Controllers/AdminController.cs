using CandyShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandyShop.Controllers
{
    public class AdminController : Controller
    {
        CarContext context;

        public AdminController(CarContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Cars.ToList());
        }

        public IActionResult Create(int? carId)
        {
            if (carId == null)
            {
                return View();
            }
            else
            {
                return View(context.Cars.FirstOrDefault(x => x.CarId == carId));
            }
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (car.CarId == 0)
            {
                context.Cars.Add(car);
            }
            else
            {
                context.Update(car);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int carId)
        {
            var carToDelete = context.Cars.Find(carId);
            context.Cars.Remove(carToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
