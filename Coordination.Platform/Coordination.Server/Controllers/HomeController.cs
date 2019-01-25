using Coordination.Server.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coordination.Server.Controllers
{
    public class HomeController : BaseController
    {
         
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            HomeIndexViewModel model=new HomeIndexViewModel();
            model.Jobs = db.Jobs.ToList();
            model.Users = db.Users.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public JsonResult GetMarkers()
        {
            return Json(new {Name="Hikaku" });

        }
    }
}
