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
    public class HomeController : Controller
    {

        private readonly yad2Context _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, yad2Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.tags = _context.Tags.ToList(); //_context.Tags.ToList();
            return View();
        }

        [Authorize]
        public IActionResult Privacy()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
