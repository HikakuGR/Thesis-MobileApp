using Coordination.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coordination.Server.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected CoordinationModel db = new Coordination.Model.CoordinationModel();
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Session["currentUser"] == null && filterContext.ActionDescriptor.ControllerDescriptor.ControllerName  != "Login" )
            {
                filterContext.Result = new RedirectResult("~/Login/Index");
            }
            
            
            base.OnActionExecuting(filterContext);
        }

    }
}
