using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yad2.Data;
using Microsoft.EntityFrameworkCore;

namespace yad2.Controllers
{
    public class StatsController : Controller
    {
        private readonly yad2Context _context;

        public StatsController(yad2Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ProductsByStores()
        {
            var query = _context.Products
                .GroupBy(product => product.store.storeName)
                .Select(p => new { storeName = p.Key, count = p.Count() });
            return Json(query.ToList());
        }

        [HttpGet]
        public JsonResult PostsByDate()
        {
            var query = _context.Posts
                   .GroupBy(p => new { d = p.PublishDate.Day, m = p.PublishDate.Month, y = p.PublishDate.Year })
                   .Select(g => new { 
                       date = g.Key.d + "." + g.Key.m + "." + g.Key.y, 
                       count = g.Count() });

            //return Json(new[] {
            //  new { amount = 15, date = "29/07/21" },
            //new { amount = 300, date = "01/08/21" }, 
            //new { amount = 100, date = "02/08/21" } 
            //});

            return Json(query.ToList());
        }
    }
}
