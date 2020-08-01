using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_WMS_Project.Controllers.Ryan_Controllers
{
    public class RyanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GaiKuo()
        {
            return View();
        }
    }
}
