using Softech.Models.DataModels;
using Softech.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Softech.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            List<JobVM> JobList;
            using (Db db = new Db())

            {
               JobList = db.Jobs.ToArray().OrderBy(x => x.DeployDate).Select(x => new JobVM(x)).ToList();
            }
            return View(JobList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Create(JobVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (Db db = new Db())
            {
                JobDTO dto = new JobDTO();
                if (db.Jobs.Any(x => x.ClientName == model.ClientName) || db.Jobs.Any(x => x.DeployDate == model.DeployDate))
                {
                    ModelState.AddModelError("", "Same client aready added");
                }
                dto.ClientName = model.ClientName;
                dto.Address = model.Address;
                dto.DeployDate = model.DeployDate;
                dto.Description = model.Description;
                dto.SoftwareName = model.SoftwareName;
                dto.Other = model.Other;
                db.Jobs.Add(dto);
                db.SaveChanges();
            }
            TempData["SM"] = "It has been Added";
            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
           JobVM model;
            using (Db db = new Db())
            {
              JobDTO dto = db.Jobs.Find(id);
                if (dto == null)
                {
                    return Content("The List doesnt exist");
                }
                model = new JobVM(dto);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(JobVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            JobDTO dto = new JobDTO();
            using (Db db = new Db())
            {

                dto = db.Jobs.Find(model.PersonId);
                dto.ClientName = model.ClientName;
                dto.Address = model.Address;
                dto.DeployDate = model.DeployDate;
                dto.SoftwareName = model.SoftwareName;
                dto.Description = model.Description;
                dto.Other = model.Other;
                //db.Transport.Attach(dto);
                db.SaveChanges();
                TempData["SM"] = "It has been Edited";
                return RedirectToAction("Edit");
            }

        }
        public ActionResult Details(int id)
        {
            // Declare PageVM
            JobVM model;

            using (Db db = new Db())
            {
                // Get the page
                JobDTO dto = db.Jobs.Find(id);

                // Confirm page exists
                if (dto == null)
                {
                    return Content("The item does not exist.");
                }

                // Init PageVM
                model = new JobVM(dto);
            }

            // Return view with model
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (Db db = new Db())
            {
                // Get the page
                JobDTO dto = db.Jobs.Find(id);

                // Remove the page
                db.Jobs.Remove(dto);

                // Save
                db.SaveChanges();
            }

            // Redirect
            return RedirectToAction("Index");
        }
    }
}
   