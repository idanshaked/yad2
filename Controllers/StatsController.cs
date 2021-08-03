using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using yad2.Data;
using yad2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace yad2.Controllers
{
    public class StatsController : Controller
    {
        private readonly yad2Context _context;

        public StatsController(yad2Context context)
        {
            _context = context;
        }


        [Authorize]
        public IActionResult Index()
        {
            string username = ((ClaimsIdentity)User.Identity).Name;
            if (!String.IsNullOrEmpty(username))
            {
                var users = from u in _context.User
                            where u.Username == username && u.isAdmin
                            select u;
                if (users.Count() == 0)
                {
                    return RedirectToAction(nameof(UsersController.AccessDenied), "Users");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction(nameof(UsersController.AccessDenied), "Users");
            }

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
