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
    }
}
