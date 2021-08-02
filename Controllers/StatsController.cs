using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yad2.Data;

namespace yad2.Controllers
{
    public class StatsController : Controller
    {
        private readonly yad2Context _context;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult PostsGroupByTags()
        {
            return Json("[300, 500, 100]");
        }

        [HttpGet]
        public JsonResult PostsByDate()
        {
            //return Json("[{'amount':300,'date':'01/08/21'},{'amount':300,'date':'01/08/21'}]");
            return Json(new[] {
                new { amount = 15, date = "29/07/21" },
                new { amount = 300, date = "01/08/21" }, 
                new { amount = 100, date = "02/08/21" } 
            });
        }
    }
}
