using Coordination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Coordination.Server.Controllers
{
    public class JobController : BaseController
    {
        
        //
        // GET: /Default1/

        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            return View();
        }

        // POST: /Job/Create
        [HttpPost]
        public ActionResult Create()
        {
            string jobName = Request["JobName"];
            string description = Request["Description"];
            string latitude = Request["Latitude"];
            string longitude = Request["Longitude"];

            Job job = new Job();
            job.JobName = jobName;
            job.Description = description;
            job.Latitude = latitude;
            job.Longitude = longitude;
            job.Assigned = false;
            job.Completed = false;

            db.Add(job);
            db.SaveChanges();

            return View("Index", db.Jobs.ToList());
        }

        // GET: /Job/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.FirstOrDefault(jb => jb.ID == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: /Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit()
        {
            string jobname = Request["JobName"];
            string description = Request["Description"];            
            int? id = int.Parse(Request["ID"]);
            string latitude = Request["Latitude"];
            string longitude = Request["Longitude"];

            Job job = db.Jobs.FirstOrDefault(jb => jb.ID == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            job.JobName = jobname;
            job.Description = description;
            job.Latitude = latitude;
            job.Longitude = longitude;

            db.Add(job);
            db.SaveChanges();
            return View("Index", db.Jobs.ToList());
        }

        public ActionResult Delete(int? id)
        {
            Job job = db.Jobs.FirstOrDefault(x => x.ID == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            
            db.Delete(job);
            db.SaveChanges();
            return View("Index", db.Jobs.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Model.Job job = db.Jobs.FirstOrDefault(x => x.ID == id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);

        }

    }
}
