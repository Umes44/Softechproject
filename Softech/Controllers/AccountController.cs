using Softech.Models.DataModels;
using Softech.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using System.Data.Entity.Infrastructure;

namespace Softech.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("~/Account/Login");
        }
        //Get:account/createaccountp
        [HttpGet]
        public ActionResult Login()
        {
            string Username = User.Identity.Name;
            if (!string.IsNullOrEmpty(Username))
                return RedirectToAction("UserProfile");
            return View();
        }
        [HttpGet]
        [ActionName("userprofile")]
        public ActionResult UserProfile()
        {
            string username = User.Identity.Name;
            UserProfile model;
            using (Db db=new Db())
            {
                //GEt user
                AccountDTO dto = db.Account.FirstOrDefault(x => x.UserName == username);
                model = new UserProfile(dto);
                
            }
            return View("UserProfile", model);
        }
        [HttpPost]
        [ActionName("userprofile")]
        public ActionResult UserProfile(UserProfile model)
        {
            if (!ModelState.IsValid)
            {
                return View("UserProfile",model);
            }
            if (!string.IsNullOrWhiteSpace(model.Password)){
                if (!model.Password.Equals(model.ConfirmPassword))
                {
                    ModelState.AddModelError("", "Password Doesnot Match");
                    return View("UserProfile", model);
                }
            }
            using (Db db =new Db())
            {
                string username = User.Identity.Name;
                if (db.Account.Where(x => x.UserId != model.UserId).Any(x => x.UserName == username))
                {
                    ModelState.AddModelError("", "Username"+model.UserName+"Already Exists");
                    model.UserName = "";
                    return View("UserProfile", model);
                }
                AccountDTO dto = db.Account.Find(model.UserId);
                dto.FirstName=model.FirstName;
                dto.LastName=model.LastName;
                dto.Email = model.Email;
                dto.Age = model.Age;
                dto.Gender = model.Gender;
                if (!string.IsNullOrWhiteSpace(model.Password))
                {
                  
                    dto.Password = model.Password;
                } 
              
                db.SaveChanges();
            }
            TempData["SM"] = "Your Profile Has been Edited";
            return Redirect("~/Account/userprofile");
        }
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            bool isvalid = false;
            using (Db db=new Db())
            {
                if (db.Account.Any(x => x.UserName.Equals(model.Username) && x.Password.Equals(model.Password)))
                {
                    isvalid = true;
                }
            }
            if (!isvalid)
            {
                ModelState.AddModelError("", "UserName or Password is Wrong");
                     return View(model);
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                return RedirectToAction("Index","Job");
            }
         
        }
        [ActionName("Createaccount")]
        [HttpGet]
        public ActionResult CreateAccount()
        {
            return View("CreateAccount");
        }
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
                int id = accounts.UserId;
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

            return RedirectToAction("Login");

        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("~/Account/Login");
        }
        public ActionResult UserNavPartial()
        {
            string username = User.Identity.Name;
            UserPartialVM model;
            using (Db db = new Db())
            {
                AccountDTO dto = db.Account.FirstOrDefault(x => x.UserName == username);

                model = new UserPartialVM()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName
                };
            }
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult ImageAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ImageAdd(UserImageVM model)
        {
           
                string filename = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                string extension = Path.GetExtension(model.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
               model.ImagePath = "~/Image/" + filename;
                filename = Path.Combine(Server.MapPath("~/Image/"), filename);
                model.ImageFile.SaveAs(filename);
            UserImageDTO dto = new UserImageDTO();
            using (Db db = new Db())
            {

                dto.Title = model.Title;
                    dto.ImageId = model.ImageId;
                    dto.ImagePath = model.ImagePath;  
                db.Images.Add(dto);
                db.SaveChanges();
                ModelState.Clear();
                TempData["SM"] = "Image Uploaded Successfully";
                return View();
            }

        }
        [HttpPost]
        public ActionResult ViewImage(int id)
        {
            UserImageDTO model;
            using (Db db = new Db())
            {
               model = db.Images.Where(x => x.ImageId == id).FirstOrDefault();
            }
            return View(model); 
        }
    }
 
} 