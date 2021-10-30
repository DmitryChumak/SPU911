using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CandyShop.Components
{
    //[ViewComponent]
    //public class Date
    //{
    //    public string Invoke()
    //    {
    //        return $"Date: {DateTime.Now.ToLongDateString()}";
    //    }
    //}
    //public class Date : ViewComponent
    //{
    //    public string Invoke()
    //    {
    //        return $"Date: {DateTime.Now.ToLongDateString()}";
    //    }
    //}
    public class DateViewComponent : ViewComponent
    {
        List<string> dates = new List<string>();
        public DateViewComponent()
        {
            dates.Add(DateTime.Now.ToLongDateString());
            dates.Add((DateTime.Now - TimeSpan.FromDays(1)).ToLongDateString());
            dates.Add((DateTime.Now - TimeSpan.FromDays(2)).ToLongDateString());
        }
        public IViewComponentResult Invoke(bool showTime)
        {
            //  return Content($"Date: {DateTime.Now.ToLongDateString()} {(showTime ? DateTime.Now.ToShortTimeString() : "")}");
            //return new HtmlContentViewComponentResult(
            //    new HtmlString($"<b>Date:</b> {DateTime.Now.ToLongDateString()} {(showTime ? DateTime.Now.ToShortTimeString() : "")}")
            //);
            return View(dates);
        }
    }
}
