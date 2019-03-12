using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softech.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        //Get:account/createaccount
        [ActionName("Createaccount")]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }
    }
}