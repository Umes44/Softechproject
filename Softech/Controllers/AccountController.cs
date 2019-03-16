using Softech.Models.DataModels;
using Softech.Models.ViewModels;
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
            return RedirectToAction("~/Account/Login");
        }
        //Get:account/createaccount
        public ActionResult Login()
        {
            string Username = User.Identity.Name;
            if (!string.IsNullOrEmpty(Username))
                return RedirectToAction("UserProfile");
            return View();
        }

        [ActionName("Createaccount")]
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }


        //Get:account/createaccount


        [HttpPost]
        public ActionResult CreateAccount(AccountVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("CreateAccount", model);
            }
            //Check if Password match
            if (!model.Password.Equals(model.ConfirmPassword))
            {
                ModelState.AddModelError("", "Password Doesnot Match");
                return View("CreateAccount", model);
            }
            //Username is Unique
            using (Db db = new Db())
            {
                if (db.Account.Any(x => x.UserName.Equals(model.UserName)))
                {
                    ModelState.AddModelError("", "Username already exists ");
                    model.UserName = "";
                    return View("CreateAccount", model);
                }

                //Create AccountDTO
                AccountDTO accounts = new AccountDTO() {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    Gender = model.Gender,
                    Email = model.Email,
                UserName = model.UserName,
                Password = model.Password
                };
                //Add AccountDTO
                db.Account.Add(accounts);
                //SAve
                db.SaveChanges();
                //Role
                int id = accounts.Id;
                UserRolesDTO userrolesdto = new UserRolesDTO()
                {
                    UserId = id,
                RolesId = 2
                };
                db.UserRoles.Add(userrolesdto);
                db.SaveChanges();
            }
            //Tempdata
            TempData["SM"] = "You are now Registered"; 

            return RedirectToAction("~/Account/Login");

        }
    }
} 