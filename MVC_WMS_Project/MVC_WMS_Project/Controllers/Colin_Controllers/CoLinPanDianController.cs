using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC_WMS_Project.Controllers.Colin_Controllers
{
    public class CoLinPanDianController : Controller
    {
        public IActionResult PDShow()
        {
            return View();
        }
        public IActionResult PDAdd()
        {
            return View();
        }
        public IActionResult PDUpdate()
        {
            return View();
        }
        public IActionResult AlertState()
        {
            return View();
        }
    }
}