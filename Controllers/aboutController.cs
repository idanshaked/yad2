using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace yad2.Controllers
{
    public class aboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
