using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softech.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Chat()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
    }
}